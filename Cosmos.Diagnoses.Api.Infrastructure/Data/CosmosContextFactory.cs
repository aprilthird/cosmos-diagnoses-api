using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Infrastructure.Data
{
    public class CosmosContextFactory : IDesignTimeDbContextFactory<CosmosContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CosmosContextFactory() { }

        public CosmosContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CosmosContext>();

            //switch (GeneralConstants.Database.DATABASE)
            //{
            //    case DataBaseConstants.MYSQL:

            //        #region Documentation

            //        // https://dev.mysql.com/doc/refman/5.6/en/innodb-restrictions.html
            //        // https://mathiasbynens.be/notes/mysql-utf8mb4
            //        // Query:
            //        // mysql: SHOW CHARACTER SET;
            //        // mysql: SHOW VARIABLES LIKE "%character%";
            //        // mysql: SHOW VARIABLES LIKE "%collation%";
            //        // mysql: SHOW VARIABLES LIKE "%innodb%";
            //        // mysql: SET default_storage_engine=INNODB;
            //        // Default:
            //        // my.ini: [mysqld] character-set-server=latin1
            //        // my.ini (Unmodifiable): [mysqld] character-set-system=utf8
            //        // my.ini (Optional): [mysqld] collation-server=latin1_german1_ci
            //        // my.ini (<= 5.6.0): [mysql] default-character-set=latin1
            //        // my.ini: [mysqld] default-storage-engine=INNODB
            //        // my.ini (>= 5.7.9): [mysqld] innodb_default_row_format=DYNAMIC
            //        // my.ini (<= 5.7.6): [mysqld] innodb_file_format=Antelope
            //        // my.ini (<= 5.7.6): [mysqld] innodb_file_format_max=Antelope
            //        // my.ini (<= 5.7.6): [mysqld] innodb_large_prefix=0
            //        // Custom:
            //        // my.ini (Optional): [mysqld] character-set-client-handshake=false
            //        // my.ini: [mysqld] character-set-server=utf8mb4
            //        // my.ini (Optional): [mysqld] collation-server=utf8mb4_general_ci
            //        // my.ini (<= 5.6.0): [mysql] default-character-set=utf8mb4
            //        // my.ini: [mysqld] default-storage-engine=INNODB
            //        // my.ini (>= 5.7.9): [mysqld] innodb_default_row_format=DYNAMIC
            //        // my.ini (<= 5.7.6): [mysqld] innodb_file_format=Barracuda
            //        // my.ini (<= 5.7.6): [mysqld] innodb_file_format_max=Barracuda
            //        // my.ini (<= 5.7.6): [mysqld] innodb_large_prefix=1
            //        // my.ini (Optional): [mysqld] skip-character-set-client-handshake
            //        #endregion
            //        builder.UseMySql(
            //            // LOCALHOST
            //            //"Server=localhost;Database=AKDEMIC5;Uid=root;Pwd=root;AllowLoadLocalInfile=true;Connection Timeout=0;Default Command Timeout=0;"

            //            //AKDEMIC - ENCH
            //            //"Server=152.44.37.241;Database=AKDEMIC5;Uid=root;Pwd=TIEnchufate.2016;AllowLoadLocalInfile=true;Connection Timeout=60;Default Command Timeout=300;"

            //            //UNCP
            //            "Server=209.50.55.102;Database=UNCP.HELPDESK.SIGAU.DB;Uid=root;Pwd=*ITUncp*2023$;AllowLoadLocalInfile=true;Connection Timeout=60;Default Command Timeout=300;"
            //            ,
            //            new MySqlServerVersion(DataBaseConstants.Versions.MySql.VALUES[DataBaseConstants.Versions.MySql.V8021])
            //            , opts =>
            //            {
            //                opts.EnableRetryOnFailure();
            //            }); ;
            //        break;
            //    case DataBaseConstants.SQL:
            //        builder.UseSqlServer(
            //            // LOCALHOST
            //            //"Server=localhost;Database=AKDEMIC5;Trusted_Connection=True;MultipleActiveResultSets=true;"

            //            //AKDEMIC - ENCH
            //            //"Server=152.44.37.241;Database=AKDEMIC;User Id=sa;Password=TIEnchufate.2016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=60;"

            //            // UNJBG
            //            "Server=181.176.223.33;Database=UNJBG.AKDEMIC5.DB;User Id=sa;Password=Ubnt$2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
            //            , opts =>
            //            {
            //                opts.EnableRetryOnFailure();
            //            });
            //        break;
            //}

            return new CosmosContext(builder.Options, _httpContextAccessor);
        }
    }
}
