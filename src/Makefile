create_local_db:
	docker run -d --name serv-db -p 5432:5432 -e POSTGRES_USER=root -e POSTGRES_PASSWORD=root -e POSTGRES_DB=serv-db postgres:15

migrate_local_db:
	migrate -path './NotificationsService/Database/Migrations' -database 'postgres://root:root@localhost:5432/serv-db?sslmode=disable&search_path=notifications' up

downgrade_local_db:
	migrate -path './NotificationsService/Database/Migrations' -database 'postgres://root:root@localhost:5432/serv-db?sslmode=disable&search_path=notifications' down 1

build_image:
	docker build . -t notifications-service:v1.0.0
