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
    LC_COLLATE = 'en_US.UTF-8'
    LC_CTYPE = 'en_US.UTF-8'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False
    TEMPLATE template0;

\c "MxcHomework"

-- SEQUENCE: public.Events_Id_seq

-- DROP SEQUENCE IF EXISTS public."Events_Id_seq";

CREATE SEQUENCE IF NOT EXISTS public."Events_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public."Events_Id_seq"
    OWNED BY public."Events"."Id";

ALTER SEQUENCE public."Events_Id_seq"
    OWNER TO "MxcHomeworkRole";

-- Table: public.Events

-- DROP TABLE IF EXISTS public."Events";

CREATE TABLE IF NOT EXISTS public."Events"
(
    "Id" integer NOT NULL DEFAULT nextval('"Events_Id_seq"'::regclass),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Location" text COLLATE pg_catalog."default" NOT NULL,
    "Country" text COLLATE pg_catalog."default",
    "Capacity" integer,
    CONSTRAINT "Events_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Events"
    OWNER to "MxcHomeworkRole";