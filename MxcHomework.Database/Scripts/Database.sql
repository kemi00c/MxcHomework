-- Role: "MxcHomeworkRole"
-- DROP ROLE IF EXISTS "MxcHomeworkRole";

CREATE ROLE "MxcHomeworkRole" WITH
  LOGIN
  NOSUPERUSER
  INHERIT
  CREATEDB
  NOCREATEROLE
  NOREPLICATION
  NOBYPASSRLS
  ENCRYPTED PASSWORD 'SCRAM-SHA-256$4096:RjUcvSPP2TGTnPPuFCR7Kg==$5BBAB0N7qWFEvUD62lAbmmpRABsDt8IhsGM0e7gJYBU=:L6rbnk4C/FU3wqN/jMbYrpyLGUQA3ymTZn5Mov+tBh8=';

-- Database: MxcHomework

-- DROP DATABASE IF EXISTS "MxcHomework";

CREATE DATABASE "MxcHomework"
    WITH
    OWNER = "MxcHomeworkRole"
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;