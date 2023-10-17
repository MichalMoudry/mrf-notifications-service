BEGIN;

CREATE TABLE notifications."Notifications" (
    "Id" UUID PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Content" VARCHAR(255) NOT NULL,
    "Type" SMALLINT NOT NULL,
    "UserId" VARCHAR(128) NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL,
    "DateAdded" TIMESTAMP NOT NULL,
    "DateUpdated" TIMESTAMP NOT NULL
);

COMMIT;