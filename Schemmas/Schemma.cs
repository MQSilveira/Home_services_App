using MySql.Data.MySqlClient;

namespace WinFormsApp.Schemmas;

public class Schemma
{
    private MySqlConnection bdConn; // MySQL

    private static string con = "server=localhost;database=clean-db;user id=root;password=''";

    public static void buildTableDb()
    {
        employeeUp();
        employerUp();
        chatUp();
        paymentUp();
    }
    
    private static void employeeUp()
    {
        MySqlConnection bdConn = new MySqlConnection(con);
        bdConn.Open();

        // Verificar se a tabela já existe
        string checkTableQuery = "SHOW TABLES LIKE 'employee'";
        MySqlCommand checkTableCommand = new MySqlCommand(checkTableQuery, bdConn);
        object result = checkTableCommand.ExecuteScalar();

        if (result == null)
        {
            // Tabela não existe, criar a tabela
            string createTableQuery = @"CREATE TABLE employee (
                                        id INT(11) AUTO_INCREMENT PRIMARY KEY,
                                        name VARCHAR(30) COLLATE utf8mb4_general_ci NOT NULL,
                                        email VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
                                        cpf_cnpj VARCHAR(20) COLLATE utf32_general_ci NOT NULL,
                                        password VARCHAR(100) COLLATE utf8mb4_general_ci NOT NULL,
                                        address VARCHAR(100) COLLATE utf8mb4_general_ci NOT NULL,
                                        skills VARCHAR(20) COLLATE utf8mb4_general_ci NOT NULL,
                                        valueSkills INT(11),
                                        level TINYINT(2) NOT NULL,
                                        isActive TINYINT(2) NOT NULL DEFAULT 1,
                                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                                    )";
            MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, bdConn);
            createTableCommand.ExecuteNonQuery();

            // Inserir valores na tabela
            string insertQuery = @"INSERT INTO employee (name, email, cpf_cnpj, password, address, skills, valueSkills, level, isActive, created_at) 
                                VALUES 
                                    ('João Silva', 'joao.silva@email.com', '123.456.789-00', 'senha123', 'Rua A, 123', 'todos', 0, 0, 1, '2023-07-08 12:00:02'), 
                                    ('Hebert', 'hebert@gmail.com', '43554088846', '123123', 'Av Testando 123', 'Todos', 0, 0, 1, '2023-07-08 12:39:02'), 
                                    ('Ana Oliveira', 'ana.oliveira@email.com', '555.666.777-88', 'senhaabc', 'Avenida D, 567', 'Pintura', 0, 0, 1, '2023-07-08 12:00:02'),
                                    ('Maria Souza', 'maria.souza@email.com', '987.654.321-00', 'senha456', 'Avenida B, 456', 'Serviços Domésticos', 0, 0, 1, '2023-07-08 12:00:02'),
                                    ('Pedro Santos', 'pedro.santos@email.com', '111.222.333-44', 'senha789', 'Rua C, 789', 'Pintura', 0, 0, 1, '2023-07-08 12:00:02'),
                                    ('Jonas Motoqueiro', 'joninha@gmail.com', '12312312312', '123123', 'Av 123 de Oliveira 4', 'Serviços Domésticos', 0, 0, 1, '2023-07-08 13:19:43'),
                                    ('Cleiton Rasta', 'cleitin@gmail.com', '12312312312', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'Av 123 de Oliviera 4', 'Serviços Domésticos', 0, 0, 1, '2023-07-08 13:24:18'),
                                    ('Claudinho', 'Claudinho@hotmail.com', '12312312335', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'Av. Ratatui', 'Manutenção Doméstica', 0, 0, 1, '2023-07-11 18:38:03'),
                                    ('Ranivon do Canivete', 'ranin@gmail.com', '3123312312', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'Av Ratata', 'Serviços Domésticos', NULL, 0, 1, '2023-07-11 19:00:11'),
                                    ('Alfredo', 'Alfredo@gmail.com', '231321321', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'Av Petequinho', 'Serviços Domésticos', NULL, 0, 1, '2023-07-11 20:55:51'),
                                    ('Florinda', 'florinda@gmail.com', '312123321', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'Flriculturasa', 'Manutenção Doméstica', NULL, 0, 1, '2023-07-11 21:02:53'),
                                    ('Camarguinho', 'Camarguinho@gmail.com', '123122121', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'AV. Ratazana 123', 'Pintura', NULL, 0, 1, '2023-07-11 21:06:02'),
                                    ('Chico Bento', 'chico.bwento@gmail.com', '123312312', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b83...', 'asASas.,sd,ajdfsa', 'Pintura', NULL, 0, 1, '2023-07-11 21:12:31')";

            MySqlCommand insertCommand = new MySqlCommand(insertQuery, bdConn);
            insertCommand.ExecuteNonQuery();
        }

        bdConn.Close();
    }
    
    private static void employerUp()
    {
        MySqlConnection bdConn = new MySqlConnection(con);
        bdConn.Open();

        // Verificar se a tabela já existe
        string checkTableQuery = "SHOW TABLES LIKE 'employer'";
        MySqlCommand checkTableCommand = new MySqlCommand(checkTableQuery, bdConn);
        object result = checkTableCommand.ExecuteScalar();

        if (result == null)
        {
            // Tabela não existe, criar a tabela
            string createTableQuery = @"CREATE TABLE employer (
                                        id INT(11) AUTO_INCREMENT PRIMARY KEY,
                                        name VARCHAR(30) COLLATE utf8mb4_general_ci NOT NULL,
                                        email VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
                                        cpf_cnpj VARCHAR(20) COLLATE utf32_general_ci NOT NULL,
                                        password VARCHAR(100) COLLATE utf8mb4_general_ci NOT NULL,
                                        address VARCHAR(100) COLLATE utf8mb4_general_ci NOT NULL,
                                        level TINYINT(4) NOT NULL,
                                        isActive TINYINT(2) NOT NULL DEFAULT 1
                                    )";
            MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, bdConn);
            createTableCommand.ExecuteNonQuery();

            // Inserir valores na tabela
            string insertQuery = @"INSERT INTO employer (
                                    name,
                                    email,
                                    cpf_cnpj,
                                    password,
                                    address,
                                    level,
                                    isActive
                                ) VALUES
                                ('João Silva', 'joao.silva@email.com', '123.456.789-00', 'senha123', 'Rua A, 123', 1, 1),
                                ('Maria Souza', 'maria.souza@email.com', '987.654.321-00', 'senha456', 'Avenida B, 456', 1, 1),
                                ('Pedro Santos', 'pedro.santos@email.com', '111.222.333-44', 'senha789', 'Rua C, 789', 1, 1),
                                ('Ana Oliveira', 'ana.oliveira@email.com', '555.666.777-88', 'senhaabc', 'Avenida D, 567', 1, 1),
                                ('Rafaela Lima', 'rafaela.lima@email.com', '111.222.333-44', 'senha123', 'Rua E, 789', 1, 1),
                                ('Felipe Pereira', 'felipe.pereira@email.com', '555.666.777-88', 'senha456', 'Avenida F, 567', 1, 1),
                                ('Marcos Santos', 'marcos.santos@email.com', '123.456.789-00', 'senha789', 'Rua G, 123', 1, 1),
                                ('Carolina Souza', 'carolina.souza@email.com', '987.654.321-00', 'senhaabc', 'Avenida H, 456', 1, 1),
                                ('Lucas Silva', 'lucas.silva@email.com', '111.222.333-44', 'senha123', 'Rua I, 789', 1, 1),
                                ('Mariana Oliveira', 'mariana.oliveira@email.com', '555.666.777-88', 'senha456', 'Avenida J, 567', 1, 1),
                                ('Gustavo Pereira', 'gustavo.pereira@email.com', '123.456.789-00', 'senha789', 'Rua K, 123', 1, 1)";

            MySqlCommand insertCommand = new MySqlCommand(insertQuery, bdConn);
            insertCommand.ExecuteNonQuery();
        }
    }
    
    private static void chatUp()
    {
        MySqlConnection bdConn = new MySqlConnection(con);
        bdConn.Open();

        // Verificar se a tabela já existe
        string checkTableQuery = "SHOW TABLES LIKE 'chat'";
        MySqlCommand checkTableCommand = new MySqlCommand(checkTableQuery, bdConn);
        object result = checkTableCommand.ExecuteScalar();

        if (result == null)
        {
            // Tabela não existe, criar a tabela
            string createTableQuery = @"CREATE TABLE chat (
                                        id INT(11) AUTO_INCREMENT PRIMARY KEY,
                                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                        update_at DATETIME,
                                        message TEXT,
                                        id_employee_FK INT(11),
                                        id_employer_FK INT(11),
                                        id_payment_FK INT(11),
                                        status TINYINT(4)
                                    )";
            MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, bdConn);
            createTableCommand.ExecuteNonQuery();
        }
    }

    private static void paymentUp()
    {
        MySqlConnection bdConn = new MySqlConnection(con);
        bdConn.Open();

        // Verificar se a tabela já existe
        string checkTableQuery = "SHOW TABLES LIKE 'payment'";
        MySqlCommand checkTableCommand = new MySqlCommand(checkTableQuery, bdConn);
        object result = checkTableCommand.ExecuteScalar();

        if (result == null)
        {
            // Tabela não existe, criar a tabela
            string createTableQuery = @"CREATE TABLE payment (
                                        id INT(11) AUTO_INCREMENT PRIMARY KEY,
                                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                        update_at DATETIME,
                                        id_employee_FK INT(11),
                                        id_employer_FK INT(11),
                                        status TINYINT(4)
                                    )";
            MySqlCommand createTableCommand = new MySqlCommand(createTableQuery, bdConn);
            createTableCommand.ExecuteNonQuery();
        }
    }
}