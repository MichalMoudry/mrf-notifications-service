SELECT
    n."Id",
    n."ContentKey",
    n."Type",
    n."DateAdded"
FROM
    "Notifications" as n
WHERE
    n."UserId" = @UserId AND n."IsDeleted" IS FALSE;