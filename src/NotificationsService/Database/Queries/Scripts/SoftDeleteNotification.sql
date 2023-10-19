UPDATE
    notifications."Notifications"
SET
    "IsDeleted" = true
WHERE
    "Id" = @NotificationId