## Table names in database

```sql
SELECT name as Name
  FROM sqlite_master
 WHERE type = 'table' AND 
       name != 'sqlite_sequence'
 ORDER BY name;
 ```

 ## Table exists in database case insensitive

 ```sql
SELECT count( * ) 
  FROM sqlite_master
 WHERE type = 'table' AND 
       name = 'contacts' COLLATE NOCASE;
 ```

 ## Computed column sample

 ```sql
 CREATE TABLE ComputedSample1 (
    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT,
    LastName  TEXT,
    FullName  STRING  AS (coalesce(trim(FirstName), '(none)') || ' ' || coalesce(trim(LastName), '(none)') ) VIRTUAL
);
```

## Create table with indexs sample

```sql
CREATE TABLE Person1 (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    FullName STRING AS (coalesce(trim(FirstName), '') || ' ' || coalesce(trim(LastName), '')) VIRTUAL,
    BirthDate date,
    Pin INTEGER
);
CREATE INDEX first_name_person1_idx ON Person1 (FirstName);
CREATE INDEX last_name_person1_idx ON Person1 (LastName);
CREATE INDEX pin_person1_idx ON Person1 (PIN);
```