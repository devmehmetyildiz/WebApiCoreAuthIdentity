using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace StarNoteWebAPICore.Migrations
{
    public partial class interpol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "partial_analysis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RAN_DATE = table.Column<string>(type: "text", nullable: true),
                    PRICE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partial_analysis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "partial_saleschart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RAN_DATE = table.Column<string>(type: "text", nullable: true),
                    PRICE = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partial_saleschart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "partial_salesman",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PRODUCT = table.Column<string>(type: "text", nullable: true),
                    PCSTYPE = table.Column<string>(type: "text", nullable: true),
                    PCS = table.Column<string>(type: "text", nullable: true),
                    PRICE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partial_salesman", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "partial_salespie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PAYMENT = table.Column<string>(type: "text", nullable: true),
                    COUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partial_salespie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_case", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Companyname = table.Column<string>(type: "text", nullable: true),
                    Companyadress = table.Column<string>(type: "text", nullable: true),
                    Taxno = table.Column<string>(type: "text", nullable: true),
                    Taxname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_costumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    İsim = table.Column<string>(type: "text", nullable: true),
                    Tckimlik = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    Şehir = table.Column<string>(type: "text", nullable: true),
                    İlçe = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_costumer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customerorder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Siparişno = table.Column<string>(type: "text", nullable: true),
                    Kayıtdetay = table.Column<string>(type: "text", nullable: true),
                    Kayıtdetay1 = table.Column<string>(type: "text", nullable: true),
                    Kayıtdetay2 = table.Column<string>(type: "text", nullable: true),
                    Tür = table.Column<string>(type: "text", nullable: true),
                    Türdetay = table.Column<string>(type: "text", nullable: true),
                    İsim = table.Column<string>(type: "text", nullable: true),
                    Tckimlik = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    Şehir = table.Column<string>(type: "text", nullable: true),
                    İlçe = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Kayıttarihi = table.Column<string>(type: "text", nullable: true),
                    Randevutarihi = table.Column<string>(type: "text", nullable: true),
                    Satıselemanı = table.Column<string>(type: "text", nullable: true),
                    Ücret = table.Column<double>(type: "double", nullable: false),
                    Önödeme = table.Column<double>(type: "double", nullable: false),
                    Beklenentutar = table.Column<double>(type: "double", nullable: false),
                    Kdv = table.Column<string>(type: "text", nullable: true),
                    Vergidairesi = table.Column<string>(type: "text", nullable: true),
                    Vergino = table.Column<string>(type: "text", nullable: true),
                    Firmaadı = table.Column<string>(type: "text", nullable: true),
                    Firmaadresi = table.Column<string>(type: "text", nullable: true),
                    Satışyöntemi = table.Column<string>(type: "text", nullable: true),
                    Ödemeyöntemi = table.Column<string>(type: "text", nullable: true),
                    Durum = table.Column<string>(type: "text", nullable: true),
                    Acıklama = table.Column<string>(type: "text", nullable: true),
                    Kullanıcı = table.Column<string>(type: "text", nullable: true),
                    Savetype = table.Column<int>(type: "int", nullable: false),
                    Talimatadliye = table.Column<string>(type: "text", nullable: true),
                    Talimatmahkeme = table.Column<string>(type: "text", nullable: true),
                    Talimatkararno = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customerorder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_filemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Mainid = table.Column<int>(type: "int", nullable: false),
                    Türadı = table.Column<string>(type: "text", nullable: true),
                    Türdetay = table.Column<string>(type: "text", nullable: true),
                    Kayıtdetay = table.Column<string>(type: "text", nullable: true),
                    Firmadı = table.Column<string>(type: "text", nullable: true),
                    Klasörno = table.Column<string>(type: "text", nullable: true),
                    Müşteriadı = table.Column<string>(type: "text", nullable: true),
                    Dosyaadı = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_filemanagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_joborder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Üstid = table.Column<int>(type: "int", nullable: false),
                    Joborder = table.Column<string>(type: "text", nullable: true),
                    Ürün = table.Column<string>(type: "text", nullable: true),
                    Ürün2 = table.Column<string>(type: "text", nullable: true),
                    Ürün2detay = table.Column<string>(type: "text", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Birim = table.Column<string>(type: "text", nullable: true),
                    Ücret = table.Column<double>(type: "double", nullable: false),
                    Durum = table.Column<string>(type: "text", nullable: true),
                    Acıklama = table.Column<string>(type: "text", nullable: true),
                    Tavsiyeedilentutar = table.Column<double>(type: "double", nullable: false),
                    Hesaplanantutar = table.Column<double>(type: "double", nullable: false),
                    Hesaplananadet = table.Column<int>(type: "int", nullable: false),
                    Kelimesayı = table.Column<int>(type: "int", nullable: false),
                    Satırsayı = table.Column<int>(type: "int", nullable: false),
                    Karaktersayı = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_joborder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_kdvsource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_kdvsource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_lisance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LisansAdı = table.Column<string>(type: "text", nullable: true),
                    Ürünanahtarı = table.Column<string>(type: "text", nullable: true),
                    Sonaermetarihi = table.Column<string>(type: "text", nullable: true),
                    Durum = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_lisance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_paymenttype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_paymenttype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_processtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_processtype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_remember",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Anakayıtid = table.Column<int>(type: "int", nullable: false),
                    AnaKayıt = table.Column<string>(type: "text", nullable: true),
                    AnaKayıtdetay = table.Column<string>(type: "text", nullable: true),
                    Hatırlatmatipi = table.Column<string>(type: "text", nullable: true),
                    Hatırlatmamesajı = table.Column<string>(type: "text", nullable: true),
                    Hatırlatmadurumu = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_remember", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rememberstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rememberstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_remembertype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_remembertype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_salesman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_salesman", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_stok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Stokkod = table.Column<string>(type: "text", nullable: true),
                    Stokadı = table.Column<string>(type: "text", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Birim = table.Column<string>(type: "text", nullable: true),
                    Alışfiyat = table.Column<double>(type: "double", nullable: false),
                    Satışfiyat = table.Column<double>(type: "double", nullable: false),
                    Kdv = table.Column<string>(type: "text", nullable: true),
                    İskonto = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_stok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_typedetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_typedetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Parameter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    İsim = table.Column<string>(type: "text", nullable: true),
                    Soyisim = table.Column<string>(type: "text", nullable: true),
                    Kullanıcıadi = table.Column<string>(type: "text", nullable: true),
                    Şifre = table.Column<string>(type: "text", nullable: true),
                    Mailadres = table.Column<string>(type: "text", nullable: true),
                    Yetki = table.Column<string>(type: "text", nullable: true),
                    Isactive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Kayıttarihi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "partial_analysis");

            migrationBuilder.DropTable(
                name: "partial_saleschart");

            migrationBuilder.DropTable(
                name: "partial_salesman");

            migrationBuilder.DropTable(
                name: "partial_salespie");

            migrationBuilder.DropTable(
                name: "tbl_case");

            migrationBuilder.DropTable(
                name: "tbl_company");

            migrationBuilder.DropTable(
                name: "tbl_costumer");

            migrationBuilder.DropTable(
                name: "tbl_customerorder");

            migrationBuilder.DropTable(
                name: "tbl_filemanagement");

            migrationBuilder.DropTable(
                name: "tbl_joborder");

            migrationBuilder.DropTable(
                name: "tbl_kdvsource");

            migrationBuilder.DropTable(
                name: "tbl_lisance");

            migrationBuilder.DropTable(
                name: "tbl_paymenttype");

            migrationBuilder.DropTable(
                name: "tbl_processtype");

            migrationBuilder.DropTable(
                name: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_remember");

            migrationBuilder.DropTable(
                name: "tbl_rememberstatus");

            migrationBuilder.DropTable(
                name: "tbl_remembertype");

            migrationBuilder.DropTable(
                name: "tbl_salesman");

            migrationBuilder.DropTable(
                name: "tbl_stok");

            migrationBuilder.DropTable(
                name: "tbl_type");

            migrationBuilder.DropTable(
                name: "tbl_typedetail");

            migrationBuilder.DropTable(
                name: "tbl_unit");

            migrationBuilder.DropTable(
                name: "tbl_users");
        }
    }
}
