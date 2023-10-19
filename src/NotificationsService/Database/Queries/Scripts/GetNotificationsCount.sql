SELECT
    COUNT(n."Id")
FROM
    notifications."Notifications" as n
WHERE
    n."UserId" = @UserId AND n."IsDeleted" IS FALSE