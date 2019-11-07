FROM mcr.microsoft.com/mssql-tools

COPY ./create-db-and-add-user.sql .

# ENV USERNAME='db-user' USERPASSWORD='db-user-pass' DATABASENAME='IdentifierGenerator' SA_PASSWORD="sa-pass" SERVER="server"

CMD [ "sh", "-c", "/opt/mssql-tools/bin/sqlcmd -U sa -P $SA_PASSWORD -S $SERVER -i ./create-db-and-add-user.sql" ]