CREATE DATABASE "db_invoice"

CREATE TABLE "invoice" (
	"id_invoice" SERIAL NOT NULL,
	"amount" NUMERIC(18,2) NULL,
	"state" INTEGER NULL,
	PRIMARY KEY ("id_invoice")
)
insert into invoice (amount, state) values (500, 0);
insert into invoice (amount, state) values (1500, 0);
insert into invoice (amount, state) values (6850, 0)