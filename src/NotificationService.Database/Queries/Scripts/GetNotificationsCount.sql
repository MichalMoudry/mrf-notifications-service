SELECT
    COUNT(n."Id")
FROM
    "Notifications" as n
WHERE
    n."UserId" = @UserId AND n."IsDeleted" IS FALSE