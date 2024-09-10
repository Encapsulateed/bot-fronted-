-- Table: public.users

-- DROP TABLE IF EXISTS public.users;

CREATE TABLE IF NOT EXISTS public.users
(
    "chatId" bigint NOT NULL,
    uuid character varying(36) COLLATE pg_catalog."default",
    "JWT" character varying(512) COLLATE pg_catalog."default",
    command character varying(128) COLLATE pg_catalog."default",
    email character varying(128) COLLATE pg_catalog."default",
    password character varying(512) COLLATE pg_catalog."default",
    CONSTRAINT users_pkey PRIMARY KEY ("chatId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.users
    OWNER to postgres;