DROP User If Exists hnckcrmuser;
CREATE User hnckcrmuser With Password 'hnckcrmpwd' NoCreateDB; 

GRANT USAGE ON SCHEMA aud To hnckcrmuser;
GRANT select, insert, update, delete On All Tables In Schema aud To hnckcrmuser;
GRANT usage On All Sequences In Schema aud To hnckcrmuser;