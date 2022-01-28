'use strict';

const gulp = require('gulp');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');
const concat = require('gulp-concat')
const uglify = require('gulp-uglify');
const del = require('del');

sass.compiler = require('node-sass');

const $ =
{
	webroot: './wwwroot/'
};

$.src =
{
	css: 'Styles/',
	js: 'Scripts/',
	fa: 'Styles/font-awesome/',
};

$.dest =
{
	js: $.webroot + 'js/',
	css: $.webroot + 'css/',
	lib: $.webroot + 'lib/',
	webfonts: $.webroot + 'webfonts/'
};

gulp.task('sass',
	function () {
		return gulp.src($.src.css + '**/*.scss')
			.pipe(
				sass({
					errLogToConsole: true,
					includePaths: ['node_modules/bootstrap/scss/']
				})
					.on('error', sass.logError))
			.pipe(gulp.dest($.src.css));
	});

gulp.task('js',
	function () {
		return gulp
			.src([$.src.js + '*.js'])
			.pipe(concat('site.js'))
			.pipe(gulp.dest($.dest.js))
			.pipe(rename('site.min.js'))
			.pipe(uglify())
			.pipe(gulp.dest($.dest.js));
	});


gulp.task('css',
	function () {
		return gulp
			.src([$.src.css + 'main.css'])
			.pipe(gulp.dest($.dest.css))
			.pipe(cleanCss())
			.pipe(rename({ suffix: '.min' }))
			.pipe(gulp.dest($.dest.css));
	});

gulp.task('_main',
	gulp.series('sass', 'css', 'js'));