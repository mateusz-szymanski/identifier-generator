FROM mcr.microsoft.com/mssql-tools

COPY ["./InfraAsCode/tools-dockerfiles/create-db-user/create-db-and-add-user.sql", "."]

CMD [ "sh", "-c", "/opt/mssql-tools/bin/sqlcmd -U sa -P $SA_PASSWORD -S $SERVER -i ./create-db-and-add-user.sql" ]