CREATE DATABASE "db_invoice"

CREATE TABLE "invoice" (
	"id_invoice" SERIAL NOT NULL,
	"amount" NUMERIC(18,2) NULL,
	"state" INTEGER NULL,
	PRIMARY KEY ("id_invoice")
)