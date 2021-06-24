#r "nuget: MySqlConnector, 1.3.10"

open MySqlConnector

let execute (conn: MySqlConnection) sql =
    use cmd = new MySqlCommand(sql, conn)
    use reader = cmd.ExecuteReader()
    let schema = reader.GetColumnSchema()

    let columns =
        [ for i in schema -> i.ColumnOrdinal.Value, i.ColumnName ]

    [ while reader.Read() do
          Map [ for ordinal, column in columns do
                    column, reader.GetValue(ordinal) ] ]

let conn =
    new MySqlConnection(
        "Server=127.0.0.1;User ID=root;port=3306;Database=test"
    )

conn.Open()

execute conn "show tables"

execute conn "create table state_populations ( state varchar(14), population int, primary key (state) )"
//execute conn "drop table state_populations"

execute conn "describe state_populations"

execute conn """
insert into state_populations (state, population) values
('Delaware', 59096),
('Maryland', 319728),
('Tennessee', 35691),
('Virginia', 691937),
('Connecticut', 237946),
('Massachusetts', 378787),
('South Carolina', 249073),
('New Hampshire', 141885),
('Vermont', 85425),
('Georgia', 82548),
('Pennsylvania', 434373),
('Kentucky', 73677),
('New York', 340120),
('New Jersey', 184139),
('North Carolina', 393751),
('Maine', 96540),
('Rhode Island', 68825)
"""

execute conn """
insert into state_populations (state, population) values
('Bolzano', 102869)
"""

execute conn "show tables"

execute conn "select * from state_populations"

execute conn "select * from state_populations where state = 'New York'"

execute conn "select name from dolt_branches"

execute conn "select * from dolt_history_state_populations"

execute conn "select message from dolt_log"

execute conn "select * from dolt_status"

execute conn "update state_populations set population = 0 where state = 'Bolzano'"
//execute conn "update state_populations set population = 4 where state = 'Bolzano'"
execute conn "update state_populations set population = 102869 where state = 'Bolzano'"

execute conn "SELECT DOLT_COMMIT('-a', '-m', 'This is a commit')"

conn.Close()
