SELECT
    n."Id",
    n."Title",
    n."Content",
    n."Type",
    n."DateAdded"
FROM
    "Notifications" as n
WHERE
    n."UserId" = @UserId AND n."IsDeleted" IS FALSE;