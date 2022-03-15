using HNCK.CRM.Common;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HNCK.CRM.WordProcessor
{
	public class DocxGenerator : IDisposable
	{
		private Document doc;
		private Application app;
		private readonly string _downloadTmpStorage;

		public DocxGenerator(string downloadTmpStorage = null)
		{
			app = new Application();
			doc = null;
			_downloadTmpStorage = string.IsNullOrEmpty(downloadTmpStorage) 
					? AppSettings.Instance.DownloadTmpStorage
					: downloadTmpStorage;

			if (Directory.Exists(_downloadTmpStorage))
				Directory.Delete(_downloadTmpStorage, true);

			Directory.CreateDirectory(_downloadTmpStorage);
		}


		public string FulFillDocxWithSubjectData<T>(T subject, string docxTemplate,string docFileName)
		{
			var data = new Dictionary<string, string>();
			foreach (var property in subject.GetType().GetProperties())
			{
				data.Add(property.Name, property.GetValue(subject)?.ToString());
			}
			return FulFillDocx(data, docxTemplate, docFileName);
		}


		public string FulFillDocx(Dictionary<string, string> data, string docxTemplate, string docFileName) 
		{
			try
			{
				var filePath = docxTemplate;
				doc = app.Documents.Open(filePath, ReadOnly: false);
				doc.Activate();

				foreach (Bookmark b in doc.Bookmarks)
				{
					foreach (var key in data.Keys)
					{
						if (b.Name.StartsWith(key))
						{
							Microsoft.Office.Interop.Word.Range rng = b.Range;
							rng.Text = data[key];
						}
					}

				}
				var newFilePath = Path.Combine(_downloadTmpStorage, $"{docFileName}_{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.docx");
				doc.SaveAs2(newFilePath);
				return newFilePath;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			if (doc != null)
				System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
			if (app != null)
				System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
			doc = null;
			app = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (doc != null)
					doc.Close(WdSaveOptions.wdDoNotSaveChanges);
				if (app != null) 
					app.Quit();
			}
		}
	}
}
