FROM mcr.microsoft.com/mssql-tools

WORKDIR "/src/InfraAsCode/create-db-user"

COPY ./create-db-and-add-user.sql .

CMD [ "sh", "-c", "/opt/mssql-tools/bin/sqlcmd -U sa -P $SA_PASSWORD -S $SERVER -i ./create-db-and-add-user.sql" ]