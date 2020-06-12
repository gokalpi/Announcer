using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcer.Data.Migrations
{
    public partial class SettingsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                table: "Settings");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "00a5751a-9109-4524-a0ec-2e3fd14339d1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "00eba878-bada-4085-b0b6-abec13325136");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0143bb4d-77a1-493f-8a2a-828ea82d24d3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "02fcbbcc-3245-475d-8881-45a30f4e12fc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "032b36c0-ff4f-4ec6-b53a-e46740c87888");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "03748a06-e75b-45e2-8aa9-a56b9aa85478");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "049953d3-4d6c-41b7-8b56-be849a40ec99");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "04ad87e5-46a3-434a-ab32-d45e99e4a482");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "06bade87-f863-4d38-aecd-75dd6f1cd07b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "071c055b-1640-4693-9014-1486f6d48c71");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "07bd0460-edba-4c60-aa28-87585309af83");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "08c7a708-7e94-4018-9b8e-d092717e0e28");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0949915e-c9f5-4f01-9da2-a2109882e60f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0ae1a4c6-e03a-40e1-abdf-8f2154051fc8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0b495873-f2dd-4677-9da4-128b0b523faa");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0c00cec4-98cc-439b-8c83-ddc06b835534");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0c449ec8-3551-4528-a7a3-ef880a026c84");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0c651bd6-eead-47e3-b420-3b3fc35550d1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0f2c5ddb-6c1d-4610-a4a6-f3cd1c7361f3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0f7ba50f-aa26-4edf-b1c6-84ecd5df1cd9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "11b89e23-caf0-4d4d-b721-c162edc493b2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "123b59aa-42c0-4364-9dba-9fa8fb94da59");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "12558902-4ece-47f4-af00-b7ac6935b833");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "12d54987-2396-4124-aedf-3cb152de5ce1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "12da3fbc-6f65-4761-8916-b66bef6406c5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "134da1be-c7f0-46e2-a18f-53e5a12b13d3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "138f7a74-2579-458f-a920-18a2eece6a57");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "145688f2-9d08-403e-b001-20da1f626639");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "164fc445-bec0-466e-aaf7-4698575b5745");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "176e4845-b5e4-48ee-b358-d7320907b3b4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "178cb058-825a-454f-8466-f83538421636");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "17904827-6e3a-486f-8184-829ed87f852d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "181850f7-6d51-414f-a904-a550ae0949b7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "181ba59a-7278-4da0-b5c5-eb9bd25d5456");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "18739f57-0142-4f98-9838-5e9e6eabbcc6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "18c65154-93d7-48de-91ff-95d42ed738c0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1b6f03ec-c732-4311-84cf-fea70316b218");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1e27604b-ea5a-4c15-851f-e1578d105863");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "20d1a506-ade1-4c87-96d3-b5ca19ace887");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2210138c-04ba-4743-9f49-9bfad83fce91");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "226c7330-c370-4877-bec1-2dea926ff878");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "227277e4-f682-499a-842c-36b68d1bdd94");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "23254e71-36c6-4eb8-9195-d7a2e264d5c9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "23749af8-36eb-462d-9750-93a8539dc1f5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "23a04691-96c4-41f0-9614-764d5629ed0f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "24d22a4c-dde8-495c-bb80-370c30326c58");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "255a31c6-49b7-4b12-8ec3-8d570801f258");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "26afbac6-bd2f-4de1-a932-53e054d724d0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "276befc6-e54a-406e-8af7-a2875195345d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "288522e8-f6b3-4940-9269-430ece3624e8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "28ace80b-c109-4962-ae37-523235215810");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "293fc83a-b5ce-4558-9353-f910bef3994d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2a90cdca-3dba-432c-9fc7-2c26a0912230");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2b585572-ad9a-40ca-bf0a-bc26ba8421be");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2b6525e5-36fc-4ffc-9c00-247b6e98a462");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2bf6f983-84b3-4329-8cfb-45cac7fc80a0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2c2fe317-c11c-44dd-a225-f844bd4e1f09");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2cbb9491-3fa6-4dc8-a12b-e17fe1d2af8a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2d4f7da2-50f8-48a5-aea8-076fc279fc40");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2d78b917-fdeb-46f8-abd9-1548bfbe7638");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2dce6a05-d95a-47a9-b7a8-c31f1182bf89");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2efa8fd6-fd87-44d9-a60f-ac8ab2059559");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "30b0ef94-21eb-45e0-8b55-14f649c9663c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "30eb11e2-6cd5-4ee2-860e-d4138970e447");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "32b3baa8-9396-4c69-a524-e331808114a1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "34684376-c82a-462a-8435-b37ffc127e12");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "35a83e82-cc22-4bb2-b5e0-919f2756e7cb");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3621bf15-7546-4af3-9230-8d586d5b1de2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "39fa9581-3341-4e0b-b32e-5a9cee0a7561");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3a69650d-a2af-443b-942d-d0d130d53aa4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3bd5abd0-4a4f-4e1b-b0ac-cbc68c66fff0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3d81d272-6ce7-4718-9368-94e39a9eae2e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3e70b752-54b3-4d78-acee-c505004784bb");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "429cab7e-0588-4d7c-a809-bba99dd2c257");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4306114d-c416-489f-8e83-39bd15ef7c30");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "434052a8-94c3-4161-89db-c1fafa878abe");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "44284e62-e797-429e-9ad6-8c2861b54eae");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "458b67a7-d784-41c3-b478-f186d3cdc34c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "46efd462-741d-4796-85ff-a0bedf8e5895");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4783fb79-d7e5-4b78-8109-875776cbb070");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "484f696e-beef-4516-ac2e-3b7fc39916a8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "48661235-23db-41b3-93c6-272a7e2b39ab");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "489e9d57-7a7f-4c41-8807-539c82168095");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "49f49823-7ff6-443e-87f9-395d309dbcc9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4a2152f5-ddba-44c3-acc0-e8cb6a22dae0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4ba2d6e2-b4c9-4973-8143-5bab539ec503");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4d0cc310-69b5-490e-aca4-1d0c87448f9b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4e8a2466-1ed2-4268-bd59-9b36d1f067d3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "527fdce4-0934-4973-b2f9-6877a75fcf09");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "52a72e1a-6468-4ef0-8c9a-9d0b9cbac83f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5503a0ee-dde5-4aec-ac55-1ed16bbc8e9a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "55b38b94-6fdf-42a7-aed7-3f4ba0b5042c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "589b241f-bad1-42fa-9048-e09e903e9e01");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5b8441d5-671f-4a27-940e-f986500bb4e4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5d285246-3f87-4d3e-b497-f616cd2df749");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5d569095-6268-4e76-82c6-8dfc654ba8f0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5db5b60e-2d41-478a-a9dd-7b678467d152");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5e3d68a8-29b1-4409-b28b-610200f6e497");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5e59a338-0e1f-4d65-94bc-6c7e90aa7867");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5e87c03a-3c5f-4d23-9677-5ebe88e79f43");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5eedc6bc-079d-4676-b7cf-1ddfa933399a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5f56525f-58a8-497e-8789-d944b3021135");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6141eeb4-e9d0-4cb4-ad0f-615d52fe8e5b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "61722061-f21f-467d-a513-f822e1990a2f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "617914c0-1a7b-4f4a-ae86-137e6d93f439");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "61b96090-1ad4-4349-9769-67b8141fbc19");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "620fded0-cc3b-46de-974e-143d6a39a85a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "62cc8021-b8b4-4ed4-9acb-b84be8907466");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "633678d0-0060-4d02-8efe-31833e46d1b1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "64484ee9-f53c-4ade-a9ba-d104232cc613");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "644a0235-650a-49cf-a5cb-dbee4e023a75");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "647cdda7-f286-4c6a-b2d1-472a7eaad0d1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "651663d1-c9ab-4eab-83ce-dbd94bdc8dc1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "67bea26e-7813-4833-a025-2156d49b523c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6956a01a-f30c-4232-90f5-1f9ebc165bc9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6a3bbfa9-e2b6-4fce-b93f-387b847e5703");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6af6aa62-2edd-4e95-95ac-05e2c60b2f1b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6b888bff-6026-4b36-89d4-6a412ab242e8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6d1d5bcd-3f5b-47a0-a71c-f4086d4a20d9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6d5cbd66-bd57-4524-a3c4-eb37645c2805");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6e46f926-90a3-42ba-951b-ec96e1e26b7e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6e987ed9-680c-43b7-b032-3b8ee1552490");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7098dfc0-ef7e-462b-ab28-06790c868c8f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7100ceae-8816-4ff7-bf09-7e43488e496c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "710900a7-8735-4607-b657-24367efac23f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "73237575-14ff-4028-9cbb-b27c744e8bad");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "74125d20-1e00-4cb9-8c5f-6992bef0bbb0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "762bf5ff-4fe3-4cb7-ae44-0e4361d6db97");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "765957a5-d0e6-4a7c-875b-44aff89939d0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "76980e89-12b6-408d-ad50-920e030cc87c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "76dbb096-4b2d-424a-999e-b796c0371b00");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "79e306d9-be57-4c78-8972-6f7d40655905");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7b78e8ce-5a40-4c71-b414-e180d2b726a7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7e456272-4ec0-401f-8c00-a2ecc689d660");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7ef114fa-5849-459c-a576-2ecb6e875642");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7f8fe196-3c4f-4e31-99f2-fcf79537e935");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7fd2a5bd-7381-4292-828c-e4bc92cd4540");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7fec90f4-7014-4efb-a2b1-5b89b213365d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "813664bf-5b5b-489e-a469-906e6ff6a1a2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "81e716e8-bee1-40f0-b496-e303c31a7e91");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "826db4cf-876c-4df1-90e5-c1aed25c896c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "83a79895-d4dd-4bae-befd-a83c98f94f1d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "874eef5f-3914-455f-a650-68aa37982674");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "87628ea5-f70b-4dff-a469-eca2a2e0ec72");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8911c122-9d44-4ef8-ba9b-561d744ca5be");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "89b34186-ac20-47f0-8df3-eb88b58fb01a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "89ff8b37-9459-4b8a-a429-8afd3d4880b4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8ac62062-536a-49d8-9264-915814355730");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8ad11479-e859-4f30-af58-48467c25a514");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8b0cb13c-e6d3-4f42-9685-298de48e479b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8c0ee74c-9b57-4be8-9ecb-a59bd669b992");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8cb83dd7-d811-483d-8cc6-4d58f3a888c8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8cb8e16f-cdf6-43dc-8b78-69d14891e182");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8ec0c55f-6900-4fcc-95fc-464b54a801bd");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "90ecdeb4-0786-4e4f-bcf4-e2fe604d7d45");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "927aaf8d-0897-459e-a103-65c0aac765d0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9286da5b-fad8-4fbb-933c-5f29694877ed");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "92c2c1a6-76ce-4422-aa8b-198a3b9fbd02");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "94f69c1f-be03-4c7a-ba37-7d2042d30a08");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "95981a58-f2fd-4133-955b-c3c587d2c2ec");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "961a22ec-73b3-4370-b830-3f5b921859ab");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "969ecbf4-013c-4c05-b0b0-3bfd6282259b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "96c8274e-0ecd-4423-bdc2-f6c3d9d860fc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "987ef194-4338-478e-a030-3f11a877ade9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "99c2e9bd-dd2f-4b19-aeac-194c23a2856b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "99c993d6-6f8e-4215-b9f2-75105dcca10e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9ba8f657-f83a-4819-a2b4-aaebe297f5a3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9cc74ec1-d209-44ad-b0eb-5cf3c94cd794");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9d262b19-21e7-462b-aecc-781bcc32eeac");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9fc6b381-c67e-46c7-ab25-183648433607");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a00c7fcc-37c3-466d-8d74-4f75377fb407");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a1362277-3436-4e99-acdf-82596f359d68");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a2eaceee-2caa-465b-a2be-fed69a7a3ae1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a3243a52-bf68-4e0e-83d5-bd67b095d7f6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a748b33a-53e3-420e-866a-605fdb67e65d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a76bd9ac-fe3e-4a8e-9d4d-aa5717d4c36b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aa028874-dbab-4103-b466-2505f375643c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aaa4af89-575b-4008-aa9e-ea6fdce8654b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aae55574-ebcf-4831-861d-853740e4351d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ab37b74d-367f-46f7-a5d8-411b516e9934");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ac8ac469-cab6-4436-b267-105e293a8c79");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aca8768b-85ab-454f-aeb0-2bb576502057");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aec5cc2c-9e15-416c-a6e0-787abe900fe8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "aed24e0e-5189-42a1-9368-f318c9a3565b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "af1ade0a-cada-43b2-99be-256aaa8671e2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "af44fe74-b993-4356-b2de-a4a34096715f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "af65330b-3e94-45de-b1ee-7d73278366f9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b00d79e7-8b4f-40a8-877d-a9dd7f251995");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b3554f17-3f56-4c10-9141-dab1f0f33c06");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b3afd932-6039-46d0-9511-a535ba5949c5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b4393e13-485f-4024-8d82-4f5d90448443");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b459c05f-c5a9-48e8-b5ed-8f0a2b82724d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b50c824e-8e70-4b69-9727-0e8470e71f16");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b6891890-c449-4e63-b338-4da8975978de");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b7c6e629-f629-49b7-873e-ebff3b442d94");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b878bf50-f871-4e76-8ab8-d29a94583335");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b883a190-911a-4e14-8c6f-34e88995eb12");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b8e4cbf1-8ea3-48b4-b698-83009c8ed206");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bbb0db9b-1ca4-4428-8fa3-fa2bff482949");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bce111ef-8611-40fb-a4c3-e9bdfbf53c28");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bd906b06-8321-4887-8c47-80b60ad4c94e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "be39c4d0-1c94-41a3-9c22-609bed2658e3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "beb18ab5-3f05-443b-b9bc-cf50b29a2a63");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "beddf605-a720-4f21-927c-0b2b97411af4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bf4580df-5d6b-496e-8ac5-42410513236b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bfbcecd7-21aa-4d4a-be0d-de878712f4a6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c094f8e1-d1a6-4e7d-ae79-61a0bd473cf6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c1a0dc00-1500-4c58-a29a-af27a11cf82d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c260c974-dfbb-41ae-ab3c-9162a5e6ff31");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c3aa8027-6c64-4c07-a923-3b69abd359ae");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c3ad1412-5a28-4a16-b0c0-16cc860e9bf7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c56d92bc-33e5-4610-9454-8ade5c160adc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c7d83ecb-35d4-46e5-9ddd-0c5896595f72");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "cbcee28e-8017-4a16-8ac7-65943ff599d0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "cd848b71-23f8-48f1-9f51-c9455ac11ba1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d14662be-2c89-4b49-bac4-58565e4ccb7f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d1b8c991-3d8f-4e83-b7fe-a7d93cbcf9d6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d1e3dd39-56ec-4d90-999a-ee5bedfb713f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d299b3be-95c3-4a7e-a233-5c0994f8e86b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d2c5eb5b-77b9-439b-ab3e-2d27404bb6dc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d337bde6-9612-4524-9823-e251e9e9edab");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d5e98ca8-db30-46a0-9459-31e1da929265");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d6639558-dabd-44d4-81ec-3cf89080ef02");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "db780c99-350c-4935-b497-1e6437644810");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dbbd77fe-833a-45bf-bb1f-b611ebe22178");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dd8fe6b9-fb96-46bf-9c2d-fe0281576374");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dddedf11-2dd4-4974-8bc3-a0d72d59ea57");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "deb2bd0d-73f1-463b-8963-89a70e3b0484");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "deedcb9a-bbbd-47fd-a4c1-3cc07aa150dc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e38f9e0d-8110-4629-962d-d7c956f923ca");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e680c723-56bb-4b10-a6e7-e8938c238d15");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eceb15f1-7871-43e7-9ef7-59db1bc38511");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "edcd364a-94e5-4fa5-9007-cacc9be42db0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ee3ede1f-ba94-4c7b-9e26-428e149e2211");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ee87d008-0bb8-4bf1-a4f2-628323c0c6e5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eecf68a2-fe1d-4072-b9d1-d717a62f430e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eef5cb6f-bbe0-4294-8dbc-1fd8e74f936c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f0b5b1af-fe23-45e6-933e-ad7ef5915667");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f0dc398f-462e-4db5-a9e7-24dcb308b58d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f2607ac2-940c-43f3-9fb2-50e9bb1e5071");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f31dc29a-6033-4470-9562-20ca2b8174a0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f5fce459-7af4-40fd-aa93-7ac7c655c24f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f6550dff-a2c5-4f07-a4fb-0a6c5c97f2fe");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f78b0a07-f611-4b09-af04-9882a71dccf0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f7ed4c71-f236-458d-a61e-37ff521c639b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f8b22f54-84c3-491c-a48b-040459e231ef");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f8c4fd66-95af-4984-9df0-5e2014ca30b6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f9ae331f-6d62-4be5-b2db-3e933d99c321");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fdf24699-0470-4581-8cf4-75fce6602f31");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Settings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                table: "Settings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "03c26518-c956-404c-9515-cb3d5046baee", "{ \"columns\": [ \"Özde Acarkan\", \"Zülal Çolak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 22, 15, 31, 0, DateTimeKind.Unspecified) },
                    { "7d9fc424-1422-4241-b63e-df0b1f51be3b", "{ \"columns\": [ \"Halime Beydağ\", \"Melek Diler Günel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 158, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 7, 27, 34, 0, DateTimeKind.Unspecified) },
                    { "526f1b34-8a53-41ed-a18a-876db5ab33bf", "{ \"columns\": [ \"Didem Bıçaksız\", \"Argun Güneri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 159, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 59, 8, 0, DateTimeKind.Unspecified) },
                    { "765df94b-44c8-423d-a9f8-1d0b5acc48a8", "{ \"columns\": [ \"Mihrinaz Bilal\", \"Mehmet Yekta Güneyi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 160, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 10, 9, 50, 0, DateTimeKind.Unspecified) },
                    { "0c08ac40-9327-4671-b595-afd4f54e13db", "{ \"columns\": [ \"Lal Bilgeç\", \"Yasemin Erva Güntek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 161, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 51, 53, 0, DateTimeKind.Unspecified) },
                    { "1c5ce163-25bb-4e19-a431-96a19f0abc16", "{ \"columns\": [ \"Senay Bilgen\", \"Günan Güral\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 162, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 4, 59, 42, 0, DateTimeKind.Unspecified) },
                    { "fa225794-f976-468f-ad42-c097df119e4c", "{ \"columns\": [ \"Remzi Bilgi\", \"Osman Cihan Gürdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 163, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 20, 19, 59, 0, DateTimeKind.Unspecified) },
                    { "1921dc60-c487-4c41-a8d0-ec66ce19e4c7", "{ \"columns\": [ \"Armağan Bilgiç\", \"Okyanus Gürel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 164, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 5, 27, 45, 0, DateTimeKind.Unspecified) },
                    { "91e384a2-8c9e-4e7f-8ec6-7e0b09112900", "{ \"columns\": [ \"Çelik Bilgir\", \"Mert Alican Güreş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 165, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 10, 59, 36, 0, DateTimeKind.Unspecified) },
                    { "f30dda98-24cb-46b6-9690-f8354253e3d9", "{ \"columns\": [ \"Kübra Tansu Bilgit\", \"Zeynep Doğa Gürses\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 166, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 17, 51, 8, 0, DateTimeKind.Unspecified) },
                    { "f0af717f-efcd-46a8-b434-17db63c8a9c5", "{ \"columns\": [ \"Uluç Emre Binbay\", \"Tarık Güven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 167, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 15, 15, 26, 0, DateTimeKind.Unspecified) },
                    { "85f17799-1694-4d04-9203-00137c3ec91f", "{ \"columns\": [ \"Mehmet Buğrahan Birgili\", \"Birgen Güvener\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 168, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 16, 22, 55, 0, DateTimeKind.Unspecified) },
                    { "35c94a0d-73e7-4d70-a774-bc8835ab4c01", "{ \"columns\": [ \"Doğuşcan Biriz\", \"Ahmet Korhan Güzel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 169, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 5, 25, 15, 0, DateTimeKind.Unspecified) },
                    { "86dd5757-026b-4a7b-bf42-6c14a4de8326", "{ \"columns\": [ \"Altan Boy\", \"Manolya Güzeller\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 170, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 12, 32, 18, 0, DateTimeKind.Unspecified) },
                    { "01729788-a599-4699-9ee8-3cd78fb52ebd", "{ \"columns\": [ \"Bengisu Boya\", \"Mustafa Berkay Güzeloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 171, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 14, 13, 55, 0, DateTimeKind.Unspecified) },
                    { "693b5459-f281-47f3-9189-684fc6fe3b13", "{ \"columns\": [ \"Onur Taylan Boylu\", \"Mehmet Anıl Hacıalioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 172, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 3, 34, 43, 0, DateTimeKind.Unspecified) },
                    { "a7896a0d-bda3-4e04-a993-3626357e53bc", "{ \"columns\": [ \"Ayseren Boyuktaş\", \"Ahmet Furkan Hacılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 173, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 19, 1, 9, 0, DateTimeKind.Unspecified) },
                    { "252f415e-25ad-429d-b710-4e1b95887543", "{ \"columns\": [ \"Pekin Boz\", \"Fazilet Hacıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 174, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 10, 56, 21, 0, DateTimeKind.Unspecified) },
                    { "9ac9b38b-d42d-4030-a4ac-18bb4bf00867", "{ \"columns\": [ \"Aksu Bozdağ\", \"Kıvılcım Hadi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 175, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 12, 4, 49, 0, DateTimeKind.Unspecified) },
                    { "6316ae19-fee2-4b07-85d1-fd257b40c0c9", "{ \"columns\": [ \"Arkan Bozdemir\", \"Çisil Hazal Hafız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 176, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 19, 31, 34, 0, DateTimeKind.Unspecified) },
                    { "7ca49436-0cc4-44cb-883f-9dffbd505414", "{ \"columns\": [ \"İltem Boztepe\", \"Feray Hakverdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 177, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 1, 38, 54, 0, DateTimeKind.Unspecified) },
                    { "7a8532ed-336c-4dab-a3f5-b46aa74fdc55", "{ \"columns\": [ \"Betül Bozyer\", \"Büşranur Halaçoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 178, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 8, 0, 21, 0, DateTimeKind.Unspecified) },
                    { "4b832fc9-ecd7-4bbb-a3d8-7ef5fc6175a0", "{ \"columns\": [ \"Ogün Bölge\", \"Selin Sıla Halıcılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 179, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 18, 21, 57, 0, DateTimeKind.Unspecified) },
                    { "86dc8169-3a2c-4b54-9704-487111777e27", "{ \"columns\": [ \"İbrahim Hakkı Bugey\", \"Yeter Hamamcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 3, 42, 1, 0, DateTimeKind.Unspecified) },
                    { "dd9e1941-aeb4-4117-a8ef-6ba5a47b8747", "{ \"columns\": [ \"Onay Buğdaypınarı\", \"Ramazan Tarık Hamarat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 181, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 13, 37, 52, 0, DateTimeKind.Unspecified) },
                    { "6866a7cd-140d-4eb2-943e-4abfd30bc9e8", "{ \"columns\": [ \"Cankız Bulgan\", \"Boran Hamidi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 182, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 4, 19, 58, 0, DateTimeKind.Unspecified) },
                    { "8e77d790-c62e-4e0a-b063-3e8992c105db", "{ \"columns\": [ \"Arzucan Bulgur\", \"Tazika Hilal Hamzaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 183, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 22, 40, 51, 0, DateTimeKind.Unspecified) },
                    { "8c457ca6-80b2-48e8-9935-783d23a48a91", "{ \"columns\": [ \"Asiye Burabak\", \"Aynur Dilan Hancı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 184, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 2, 8, 47, 0, DateTimeKind.Unspecified) },
                    { "5d80a530-eb23-49f0-9ed1-0726b2b6b02a", "{ \"columns\": [ \"Buse Gizem Berker\", \"Eylem Gündüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 157, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 18, 10, 0, DateTimeKind.Unspecified) },
                    { "2c14f419-8985-4aab-9303-3145cf4d7e94", "{ \"columns\": [ \"Ahmet Yasin Burak\", \"Ayman Hangül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 185, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 21, 2, 50, 44, 0, DateTimeKind.Unspecified) },
                    { "6a7a984b-d75e-452d-af09-7afc36b52c0f", "{ \"columns\": [ \"Hüner Berk\", \"Öymen Gümüşsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 156, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 21, 14, 45, 0, DateTimeKind.Unspecified) },
                    { "8fcf5306-220d-49e9-bbe0-01da2cac167c", "{ \"columns\": [ \"Hulki Bent\", \"Köksal Gültaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 154, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 35, 26, 0, DateTimeKind.Unspecified) },
                    { "83a87992-aac6-48c2-ba3b-daeed892ed56", "{ \"columns\": [ \"Serdar Kaan Barbaros\", \"Kubra Göçmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 127, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 17, 10, 6, 0, DateTimeKind.Unspecified) },
                    { "8146c340-75dc-452c-85a6-5c04382dcc74", "{ \"columns\": [ \"Ezel Bargan\", \"Kubilay Gödek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 128, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 49, 28, 0, DateTimeKind.Unspecified) },
                    { "a13c037e-5a8c-46c2-b98a-14a93b219ee8", "{ \"columns\": [ \"Ayşegül Barutçuoğlu\", \"Busem Gökçeaslan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 129, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 1, 58, 28, 0, DateTimeKind.Unspecified) },
                    { "5c2bf23f-c5fd-4486-bd96-890afb5ff353", "{ \"columns\": [ \"Sefa Kadir Başar\", \"Banuhan Gökçek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 130, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 6, 15, 21, 0, DateTimeKind.Unspecified) },
                    { "8f7a5331-1856-4596-bffe-bf912ff9d4fa", "{ \"columns\": [ \"Elif Etga Başeğmez\", \"Örgün Gökhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 131, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 2, 3, 20, 0, DateTimeKind.Unspecified) },
                    { "61d2a475-2e80-43e3-912a-fc6da7f0eb9a", "{ \"columns\": [ \"Balın Baştepe\", \"Melike Göksoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 132, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 42, 8, 0, DateTimeKind.Unspecified) },
                    { "8273403f-40c0-4763-b155-ed5a44a7ab35", "{ \"columns\": [ \"Mahperi Baştopçu\", \"Yeşim Gölmes\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 133, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 26, 28, 0, DateTimeKind.Unspecified) },
                    { "0f2e5292-efb7-4e7b-8f5c-983d30a6195a", "{ \"columns\": [ \"Erol Özgür Baştuğ\", \"Nilüfer Gönay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 134, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 22, 39, 49, 0, DateTimeKind.Unspecified) },
                    { "4655cbff-16aa-4f11-be49-1a83ff7c71a2", "{ \"columns\": [ \"Atak Batar\", \"Denizhan Gönül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 135, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 10, 10, 33, 0, DateTimeKind.Unspecified) },
                    { "48d26b9b-4e5f-4008-b7f1-feabd9cae090", "{ \"columns\": [ \"Safa Batga\", \"Şueda Göreke\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 136, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 21, 5, 6, 53, 0, DateTimeKind.Unspecified) },
                    { "28844d9e-25b2-4177-bbec-5ee0074325c6", "{ \"columns\": [ \"Gökmen Battal\", \"Ersin Görgülü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 137, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 18, 7, 24, 0, DateTimeKind.Unspecified) },
                    { "a1ecdcef-71a9-4133-813e-f035fb2bf4da", "{ \"columns\": [ \"Fazıl Erem Batuk\", \"Şahabettin Görgüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 138, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 22, 50, 59, 0, DateTimeKind.Unspecified) },
                    { "6cc859c3-623f-432a-bf86-03fb9a45f2cd", "{ \"columns\": [ \"Bensu Batur\", \"Ayşe Elif Görür\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 139, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 15, 40, 0, DateTimeKind.Unspecified) },
                    { "d8f39db6-4177-4852-83c3-2ca7d06efc11", "{ \"columns\": [ \"Nazım Orhun Baturalp\", \"Nazım Berke Göven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 140, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 2, 59, 2, 0, DateTimeKind.Unspecified) },
                    { "f9f14cbf-98a3-4ad6-a776-409af2d482c3", "{ \"columns\": [ \"Safa Ahmet Baydar\", \"Meltem Göymen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 141, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 37, 28, 0, DateTimeKind.Unspecified) },
                    { "d76c7f85-3b30-484a-9f5a-e705dbfe0ced", "{ \"columns\": [ \"Demircan Baydil\", \"Abdulhalim Guguk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 142, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 16, 0, 53, 0, DateTimeKind.Unspecified) },
                    { "ee4401e3-f4c3-4351-8968-000078f9068c", "{ \"columns\": [ \"Burçin Kübra Baykal\", \"Gülten Güdücü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 143, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 12, 19, 44, 0, DateTimeKind.Unspecified) },
                    { "fecbb456-991b-4b95-937e-ffbb9646746f", "{ \"columns\": [ \"Derviş Haluk Baykan\", \"Işınbıke Gülcan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 144, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 19, 0, 58, 0, DateTimeKind.Unspecified) },
                    { "eaba0fa5-7216-4284-952a-0da1023f73ce", "{ \"columns\": [ \"Taylan Remzi Baykuş\", \"Vedia Gülçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 145, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 11, 3, 45, 0, DateTimeKind.Unspecified) },
                    { "67003735-f8f9-4022-baf2-d5687f9484ed", "{ \"columns\": [ \"Abdulvahap Bayrakoğlu\", \"Fatma Sena Güldoğuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 146, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 8, 34, 23, 0, DateTimeKind.Unspecified) },
                    { "708f0ccf-19ab-462d-b7fd-2a96d7004dc4", "{ \"columns\": [ \"Aygün Bayram\", \"Ömer Okan Gülebakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 147, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 13, 16, 12, 0, DateTimeKind.Unspecified) },
                    { "b681e880-4052-403e-8b93-1103c6b5fc86", "{ \"columns\": [ \"Ayla Baytın\", \"Aybike Güleç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 148, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 28, 27, 0, DateTimeKind.Unspecified) },
                    { "6b932980-e2a0-4ca0-811f-32817dd70f9e", "{ \"columns\": [ \"Kubilay Barış Begiç\", \"Bektaş Gülenç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 149, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 6, 49, 0, DateTimeKind.Unspecified) },
                    { "d91155ea-300a-4078-87a0-ba796a4d8f1e", "{ \"columns\": [ \"Mustafa Samed Beğenilmiş\", \"Emircan Güleryüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 20, 37, 0, DateTimeKind.Unspecified) },
                    { "f516af08-a32c-41a9-8afb-ef628966e7ef", "{ \"columns\": [ \"Berfin Dilay Bekaroğlu\", \"Merter Gülkan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 151, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 14, 53, 12, 0, DateTimeKind.Unspecified) },
                    { "d281f897-9306-4eb1-aa6a-84dd8f15d7cf", "{ \"columns\": [ \"İbrahim Onat Belge\", \"Sevgi Tutku Güllüce\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 152, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 10, 45, 7, 0, DateTimeKind.Unspecified) },
                    { "63c1ca55-fa66-44dd-b319-76274ad734b5", "{ \"columns\": [ \"Jutenya Benan\", \"Denktaş Gülşen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 153, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 21, 14, 22, 0, DateTimeKind.Unspecified) },
                    { "b42087a1-1827-47b7-9de8-4ca238b086d5", "{ \"columns\": [ \"Mustafa Doğukan Berberoğlu\", \"Hasan Fahri Gültepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 155, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 14, 44, 16, 0, DateTimeKind.Unspecified) },
                    { "8348e57a-009a-4ed6-8b5e-c3d530b0e022", "{ \"columns\": [ \"Yaprak Bural\", \"Berrak Harman\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 186, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 22, 10, 53, 0, DateTimeKind.Unspecified) },
                    { "151481cf-d82f-46ec-914f-eedd165e34ff", "{ \"columns\": [ \"Aleda Buyuran\", \"Erk Deha Harmankaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 187, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 0, 41, 0, DateTimeKind.Unspecified) },
                    { "4fcaf09f-c451-446c-b185-236268905dff", "{ \"columns\": [ \"Can Güney Bülbül\", \"Perihan Haykır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 188, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 11, 4, 40, 0, DateTimeKind.Unspecified) },
                    { "41f7830a-b288-45cd-a3eb-4a35a02bf7b1", "{ \"columns\": [ \"Mahire Çalım\", \"Bergüzar Kaçaranoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 221, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 10, 18, 45, 0, DateTimeKind.Unspecified) },
                    { "49cf63b6-7379-403b-be0c-06236922f71b", "{ \"columns\": [ \"Hacı Bayram Ufuk Çamaş\", \"Ömer Faruk Kadı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 222, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 12, 13, 48, 0, DateTimeKind.Unspecified) },
                    { "e793d4e8-79c3-42b1-b7ae-8c6cd335c46e", "{ \"columns\": [ \"Oltun Çanga\", \"Dağhan Kadoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 223, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 19, 24, 58, 0, DateTimeKind.Unspecified) },
                    { "606f0813-40dc-4284-bacd-f29ca18ff083", "{ \"columns\": [ \"Önel Çapa\", \"Ünzile Kalfaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 224, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 8, 36, 10, 0, DateTimeKind.Unspecified) },
                    { "45068c94-7d37-463f-817e-6e7c6aa60a93", "{ \"columns\": [ \"Bayülken Çaprak\", \"Sezer Kalsın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 225, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 3, 12, 24, 0, DateTimeKind.Unspecified) },
                    { "7c84ed49-11e4-4c83-b93b-26deab405cff", "{ \"columns\": [ \"Dilseren Çarıcı\", \"Şensoy Kalyoncu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 226, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 14, 32, 23, 0, DateTimeKind.Unspecified) },
                    { "189718b9-bb4b-4256-8492-899f515a24be", "{ \"columns\": [ \"Elif Beyza Çark\", \"Necatı Kamışlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 227, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 11, 44, 37, 0, DateTimeKind.Unspecified) },
                    { "70f5f963-7083-43ab-952b-eaca92eabda0", "{ \"columns\": [ \"Elvan Çatal\", \"Şahan Kandaşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 228, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "7c1810ef-fb34-40f0-b3a6-8b70a47e2e06", "{ \"columns\": [ \"Esim Çaylar\", \"Necip Fazıl Kanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 229, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 11, 38, 41, 0, DateTimeKind.Unspecified) },
                    { "98f21f85-e9b0-4085-80df-1cd47856ab48", "{ \"columns\": [ \"Sena Çekmecelioğlu\", \"Muharrem Kanmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 230, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 21, 2, 33, 17, 0, DateTimeKind.Unspecified) },
                    { "7578590e-8c05-498b-8986-0ce257f39299", "{ \"columns\": [ \"Muhammed Üzeyir Çekmeci\", \"Zeynep Figen Kantarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 231, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 0, 56, 0, DateTimeKind.Unspecified) },
                    { "19dde402-9b05-40c1-a79f-3d7947ef4f20", "{ \"columns\": [ \"Aydın Mert Çelebican\", \"Çilay Kapsız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 232, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 10, 8, 25, 0, DateTimeKind.Unspecified) },
                    { "778df9b4-659f-41bc-8e90-0eed41c882e0", "{ \"columns\": [ \"Çağkan Çelenlioğlu\", \"Suna Karaaslanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 233, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 14, 17, 11, 0, DateTimeKind.Unspecified) },
                    { "643cedd3-de1a-4835-9ee8-1ea444d4eff7", "{ \"columns\": [ \"Zümra Çelık\", \"Ahmet Can Karabacak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 234, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 18, 20, 41, 0, DateTimeKind.Unspecified) },
                    { "1eea15c6-fe75-4fcb-af8c-dec451f7f709", "{ \"columns\": [ \"Bayar Çelik\", \"Asya Sema Karabağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 235, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 3, 54, 2, 0, DateTimeKind.Unspecified) },
                    { "2e3cd26d-fabd-4071-85a7-a488fba77f03", "{ \"columns\": [ \"Gönülgül Çelikağı\", \"Gül Sena Karabıyık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 236, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 1, 17, 39, 0, DateTimeKind.Unspecified) },
                    { "b4c4df06-edca-4a7a-a574-0a165b2aa77e", "{ \"columns\": [ \"Ece Pınar Çeliker\", \"Fatma Büşra Karabıyıklı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 237, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 6, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "be74478e-9caf-4323-a37a-d16861edb88f", "{ \"columns\": [ \"Mehmet Tarık Çelikkol\", \"Arca Karabulut\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 238, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 10, 7, 29, 0, DateTimeKind.Unspecified) },
                    { "b88591a5-93b4-4349-a8d3-bc3d7753438b", "{ \"columns\": [ \"Elife Çerçi\", \"Abdullatif Karacabey\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 239, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 6, 6, 10, 0, DateTimeKind.Unspecified) },
                    { "e79806be-9a1d-43c2-9fde-5cd6865802db", "{ \"columns\": [ \"Efecan Çetintaş\", \"Tuğra Karacan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 240, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 6, 32, 13, 0, DateTimeKind.Unspecified) },
                    { "dd630381-54e3-45ef-b308-01fb17cc985e", "{ \"columns\": [ \"Rıdvan Çıkıkcı\", \"Emir Doğan Karaçay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 241, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 7, 58, 42, 0, DateTimeKind.Unspecified) },
                    { "3e6fb6a1-763a-437d-bacf-89b2cd0f1dc4", "{ \"columns\": [ \"Hatice Gamze Çınar\", \"Haluk Barış Karaçeşme\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 242, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 3, 8, 19, 0, DateTimeKind.Unspecified) },
                    { "c8ea198d-0dfe-4921-b7fd-185eb064c093", "{ \"columns\": [ \"Yansı Hilal Çınaroğlu\", \"Seyit Ahmet Karadağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 243, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 57, 51, 0, DateTimeKind.Unspecified) },
                    { "208e3912-ca8d-4bb1-b6e8-eea84077a1ae", "{ \"columns\": [ \"Omaç Çıngır\", \"Cevza Karadalan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 244, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 4, 22, 52, 0, DateTimeKind.Unspecified) },
                    { "eb554fe7-8b5e-4064-9cbc-945e1af9a49c", "{ \"columns\": [ \"Erhan Çıray\", \"Mustafa Emir Karademir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 245, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 23, 13, 26, 0, DateTimeKind.Unspecified) },
                    { "3524e982-e5cd-4a45-863d-6af92ba8f246", "{ \"columns\": [ \"Şüheda Çiçekli\", \"Ilgar Pamir Karaismail\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 246, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 1, 10, 50, 0, DateTimeKind.Unspecified) },
                    { "fc8a8e4d-fd67-45aa-aa8f-94caf55db501", "{ \"columns\": [ \"Ünkan Çini\", \"Seren Karakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 247, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 17, 32, 0, DateTimeKind.Unspecified) },
                    { "c6e6d8bb-7b16-46ca-a8de-ad85fda87fdf", "{ \"columns\": [ \"Maral Çakıcı\", \"Şaziye Kabukçu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 220, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 20, 21, 1, 0, DateTimeKind.Unspecified) },
                    { "760f8904-2e8a-43b2-81ec-9da085ee008c", "{ \"columns\": [ \"Dilhan Çakanel\", \"Melis Ezgi Kabayuka\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 219, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 11, 58, 0, DateTimeKind.Unspecified) },
                    { "1f165671-895c-4f84-8806-626b19a5f29c", "{ \"columns\": [ \"Özen Çakan\", \"Uzel Kabataş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 218, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 11, 53, 6, 0, DateTimeKind.Unspecified) },
                    { "037514f5-096b-4c3d-9b40-0b660efda066", "{ \"columns\": [ \"Elif Ege Çağlayan\", \"Ahuşen İşgüzar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 217, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 23, 43, 16, 0, DateTimeKind.Unspecified) },
                    { "63bd2028-e743-47c0-ba47-a90ccee3b6ac", "{ \"columns\": [ \"Mahmut Bilal Bülend\", \"Turhan Onur Hırlak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 189, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 8, 28, 45, 0, DateTimeKind.Unspecified) },
                    { "4431ab0f-f631-4ca2-82b9-b1ff373dfa80", "{ \"columns\": [ \"Saliha Zeynep Bülent\", \"Furkan Hızarcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 190, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 7, 58, 41, 0, DateTimeKind.Unspecified) },
                    { "96b3fc37-4858-4a73-ac7c-0231293a7931", "{ \"columns\": [ \"Melike Dilara Büyükfırat\", \"Mustafa Ali Hiçyılmam\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 191, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 20, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { "fb8ea99e-eb1f-48c9-82dc-1f9749f72cb9", "{ \"columns\": [ \"Hayriye Büyükgüngör\", \"Muhammed Sefa Hilal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 192, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 12, 45, 42, 0, DateTimeKind.Unspecified) },
                    { "9f762187-bc3e-4d3e-833a-5526ac18f3d3", "{ \"columns\": [ \"Sebiha Büyüköztürk\", \"Argün Hilmi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 193, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 10, 25, 56, 0, DateTimeKind.Unspecified) },
                    { "b4674279-cead-4319-ac3b-2454864e6c49", "{ \"columns\": [ \"Mehmet Can Akçaözoğlu\", \"Fadik Himoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 194, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 21, 3, 57, 41, 0, DateTimeKind.Unspecified) },
                    { "3677c192-8d30-4a0f-9acb-5b53919f7e2f", "{ \"columns\": [ \"Mehmet Enes Canan\", \"Ahmet Hakkı Hirik\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 195, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 9, 8, 41, 0, DateTimeKind.Unspecified) },
                    { "8d07555e-74aa-4d1d-8160-2a6db235665e", "{ \"columns\": [ \"Kurtbey Canbağı\", \"Mustafa Sefa Hopacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 196, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 10, 35, 32, 0, DateTimeKind.Unspecified) },
                    { "b29e6293-78e1-47f5-baf1-1fddcb043d53", "{ \"columns\": [ \"Mustafa Taha Canbek\", \"Toykan Horata\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 197, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 14, 38, 48, 0, DateTimeKind.Unspecified) },
                    { "4f0d10f0-f489-402d-a2da-4ced4ae12638", "{ \"columns\": [ \"Sena Nur Candan\", \"Selime Hüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 198, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 4, 51, 29, 0, DateTimeKind.Unspecified) },
                    { "1791660b-4af2-4251-9df3-e73aa06319c5", "{ \"columns\": [ \"Abdullah Emirhan Caner\", \"Denizcan Ilık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 199, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 23, 44, 6, 0, DateTimeKind.Unspecified) },
                    { "221c072c-5683-45f6-a1ed-7c9b15f2f0df", "{ \"columns\": [ \"Mustafa Kerem Cansu\", \"Ayşe Zeyneb Irıcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 34, 2, 0, DateTimeKind.Unspecified) },
                    { "72c7e9d1-0e14-41a4-9a3d-6b50fa8bfed6", "{ \"columns\": [ \"Doktora Canuyar\", \"Mustafa Furkan Işınay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 201, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 11, 16, 38, 0, DateTimeKind.Unspecified) },
                    { "13d8d003-91e5-4b0a-bfd2-35892f922dc0", "{ \"columns\": [ \"Coşkun Baran\", \"Tilbe Göç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 126, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 21, 11, 38, 0, DateTimeKind.Unspecified) },
                    { "94ec00d2-f79d-4036-ab62-95b87769af55", "{ \"columns\": [ \"Seyit Ceran\", \"Sude İbrahim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 202, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 17, 47, 59, 0, DateTimeKind.Unspecified) },
                    { "fb0db6ab-1776-478a-abf7-4ab9dd79bbba", "{ \"columns\": [ \"Aşkım Chiklyaukova\", \"Katya İlgezdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 204, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 4, 49, 51, 0, DateTimeKind.Unspecified) },
                    { "c6d7859e-d59c-4415-b687-0facbe6ef73d", "{ \"columns\": [ \"Özgür Choi\", \"Halid İlhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 205, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 16, 3, 4, 0, DateTimeKind.Unspecified) },
                    { "1e6710a7-7889-4188-807d-621a62dd7ff3", "{ \"columns\": [ \"Tuğce Cibooğlu\", \"Nihal İlısu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 206, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 57, 28, 0, DateTimeKind.Unspecified) },
                    { "cc8be8d8-90ba-4565-8733-f770258afecf", "{ \"columns\": [ \"Özer Seçkin Ciddi\", \"Elif Nisan İmamoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 207, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 16, 36, 14, 0, DateTimeKind.Unspecified) },
                    { "7168264a-8593-47a8-841b-a6de940f94a1", "{ \"columns\": [ \"Balkın Cigerlioğlu\", \"Emine Selcen İmre\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 208, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 20, 26, 52, 0, DateTimeKind.Unspecified) },
                    { "9505cb80-688c-41ad-977c-70c43e1d0a4c", "{ \"columns\": [ \"Yücel Civan\", \"Tevfik İnal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 209, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 4, 2, 0, DateTimeKind.Unspecified) },
                    { "a83a12ad-99b1-486d-b117-56ddf6260d53", "{ \"columns\": [ \"Şansal Coşan\", \"İbrahim Kağan İncekara\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 210, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 19, 51, 38, 0, DateTimeKind.Unspecified) },
                    { "12403480-ab7d-473b-8b8f-efe5eb4dccfd", "{ \"columns\": [ \"Oğuzcan Coşandal\", \"Sidar İnceoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 211, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 6, 14, 55, 0, DateTimeKind.Unspecified) },
                    { "7bb80287-bd85-4896-bea8-36066dc2f5c0", "{ \"columns\": [ \"Mayıs Cumalı\", \"Nesli İpçizade\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 212, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 16, 19, 36, 0, DateTimeKind.Unspecified) },
                    { "a4ff2ca1-f301-42a6-b53a-0caf924164f7", "{ \"columns\": [ \"Büşra Cüce\", \"İhsan Vehbi İpekoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 213, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 8, 28, 52, 0, DateTimeKind.Unspecified) },
                    { "9c6c3138-4a90-449d-8a9e-2e224061af2a", "{ \"columns\": [ \"Afra Selcen Çağan\", \"Necati İrsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 214, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 7, 59, 0, DateTimeKind.Unspecified) },
                    { "b9d206c8-89b8-41fc-a8be-744e4c8df80f", "{ \"columns\": [ \"Gönül Çağatay\", \"Zerin İshakoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 215, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 4, 59, 44, 0, DateTimeKind.Unspecified) },
                    { "e568442b-ea2c-4dc9-afde-29eaa33c76d7", "{ \"columns\": [ \"Doğangün Çağlar\", \"Dursun Korel İşgören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 216, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 14, 6, 11, 0, DateTimeKind.Unspecified) },
                    { "9cd13332-2e7d-44a2-9f58-11207cf2afd3", "{ \"columns\": [ \"Selma Simge Ceylan\", \"Güçlü İçten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 203, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 9, 30, 8, 0, DateTimeKind.Unspecified) },
                    { "df3b062a-4433-469e-90a4-dc13a9a4670b", "{ \"columns\": [ \"Ahmet Gazi Çintan\", \"Büşra Hazal Karakaplan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 248, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 29, 21, 0, DateTimeKind.Unspecified) },
                    { "0a6d7ea5-b0be-4888-9ab8-196588486076", "{ \"columns\": [ \"Abdullah Atakan Baluken\", \"Abdullah Halit Golba\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 125, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 2, 58, 0, DateTimeKind.Unspecified) },
                    { "062bd780-ee68-4870-83eb-c536d44a70db", "{ \"columns\": [ \"Sakıp Balıoğlu\", \"Mehmet Gökalp Ginoviç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 123, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 9, 42, 35, 0, DateTimeKind.Unspecified) },
                    { "904af133-216f-477e-8ede-be520ee9e980", "{ \"columns\": [ \"Nüket Aksan\", \"Bedir Destereci\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 33, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 7, 55, 50, 0, DateTimeKind.Unspecified) },
                    { "96c7dac3-8795-473c-9e93-8b5779912627", "{ \"columns\": [ \"Senem Aksevim\", \"Rümeysa İrem Devecel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 6, 21, 36, 0, DateTimeKind.Unspecified) },
                    { "422b62ce-8608-406a-b516-03bc3979139d", "{ \"columns\": [ \"Ayşen Aksoy\", \"Osman Sinan Devrim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 18, 25, 29, 0, DateTimeKind.Unspecified) },
                    { "d97dd9a5-0990-4d6f-b086-e0559b30c30d", "{ \"columns\": [ \"Pekcan Aksöz\", \"Saliha Canan Dıvarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 20, 16, 22, 43, 0, DateTimeKind.Unspecified) },
                    { "8db8c236-c51a-4d50-a19c-cd80b2751f3e", "{ \"columns\": [ \"Bedirhan Lütfü Akşamoğlu\", \"Samet Emre Dikbaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 20, 9, 4, 0, DateTimeKind.Unspecified) },
                    { "d4ab796e-9472-4cbd-bd3f-c34a6e7337d1", "{ \"columns\": [ \"Semina Aktuna\", \"Haldun Dinçtürk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 5, 6, 0, DateTimeKind.Unspecified) },
                    { "17bb519e-0eae-4125-bebb-a308f96bf958", "{ \"columns\": [ \"Eda Sena Akyıldız\", \"Goncagül Diri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 10, 11, 27, 0, DateTimeKind.Unspecified) },
                    { "3940c165-8a5c-44fa-9117-81761cb788da", "{ \"columns\": [ \"Müyesser Akyildirim\", \"Ziya Doğramacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 26, 45, 0, DateTimeKind.Unspecified) },
                    { "4c48f469-5fd6-45bc-8ef2-f9b19f141d12", "{ \"columns\": [ \"Selinti Al\", \"Zehra Pelin Döger\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 9, 3, 34, 0, DateTimeKind.Unspecified) },
                    { "840aa840-0b21-41c1-86e3-768072a3177c", "{ \"columns\": [ \"Bahar Özlem Albaş\", \"Seli M Sharef Dökülmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 58, 37, 0, DateTimeKind.Unspecified) },
                    { "fa4126c5-0a2e-47cb-88ac-f41eae8e8e03", "{ \"columns\": [ \"İlma Aldağ\", \"Firuze Dönder\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 43, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 48, 44, 0, DateTimeKind.Unspecified) },
                    { "693b6753-b0ab-4492-8bed-bea23bc2595f", "{ \"columns\": [ \"Kutlu Alibeyoğlu\", \"Doruk Deniz Döner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 15, 40, 2, 0, DateTimeKind.Unspecified) },
                    { "ae6885b0-37cf-4482-8866-f95dffc2ab7b", "{ \"columns\": [ \"Nesibe Nurefşan Alkan\", \"Çisil Zeynep Dönmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 22, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "fcfd2ea3-46b9-4c58-892e-ebb0eda3eb40", "{ \"columns\": [ \"Ömer Buğra Alparslan\", \"Tugce Dudu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 46, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 16, 14, 54, 0, DateTimeKind.Unspecified) },
                    { "2bca9439-1e31-4bd3-959a-38f053201bc6", "{ \"columns\": [ \"Hiba Alpuğan\", \"Enver Dur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 47, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 41, 42, 0, DateTimeKind.Unspecified) },
                    { "4de104b2-dc84-47b3-b20b-561b611190e9", "{ \"columns\": [ \"Mazlum Altan\", \"Sanber Durak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 48, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 22, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "6ad58fc1-13f2-4110-8987-186e6516bf10", "{ \"columns\": [ \"Elif Tuğçe Altaş\", \"Birsen Durmuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 49, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 13, 24, 34, 0, DateTimeKind.Unspecified) },
                    { "4d66b847-fddf-44f8-a4af-e6c9d3481861", "{ \"columns\": [ \"Ahmet Ruken Altay\", \"Taçmin Durmuşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 1, 18, 6, 0, DateTimeKind.Unspecified) },
                    { "664e2050-bccd-4c76-ab96-f2bd10c7a45f", "{ \"columns\": [ \"Yaşar Utku Anıl Altın\", \"Karanalp Dursun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 51, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 18, 49, 0, DateTimeKind.Unspecified) },
                    { "d9c3a423-70ef-4bf2-9688-0e28c4c07508", "{ \"columns\": [ \"Rana Altınoklu\", \"Öktem Duymuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 52, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 8, 31, 0, DateTimeKind.Unspecified) },
                    { "812a10c8-1420-456d-aeb9-26051b01962f", "{ \"columns\": [ \"Fethullah Altınöz\", \"Elanaz Dülgerbaki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 53, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 19, 28, 29, 0, DateTimeKind.Unspecified) },
                    { "0fd97f2b-cbd5-4b4e-a743-a462a1173a99", "{ \"columns\": [ \"Burak Tatkan Altıntaş\", \"Fidan Dündar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 54, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 7, 32, 0, DateTimeKind.Unspecified) },
                    { "f2290b25-322b-4104-84b6-2b4e2ff3b947", "{ \"columns\": [ \"Merve Ece Altıok\", \"Barın Düşenkalkar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 55, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 20, 58, 35, 0, DateTimeKind.Unspecified) },
                    { "dccbadbd-e325-4cc4-a031-7909cc691f4f", "{ \"columns\": [ \"Rima Altıparmak\", \"Mehmet Erman Düzbayır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 56, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 20, 7, 20, 0, DateTimeKind.Unspecified) },
                    { "1a332232-fdfa-4faa-bf5d-14508165e2dd", "{ \"columns\": [ \"Elif Dilay Altinkaya\", \"Cem Efe Edeş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 57, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 11, 6, 33, 0, DateTimeKind.Unspecified) },
                    { "80a36603-441f-41b3-8d34-8eeaab302948", "{ \"columns\": [ \"Sırma Begüm Altunbaş\", \"Erem Edibali Mp\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 58, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 10, 50, 5, 0, DateTimeKind.Unspecified) },
                    { "2c223878-fc58-4580-81b6-691cdf878986", "{ \"columns\": [ \"Nefse Altunbulak\", \"Volkan Eyüp Efşin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 59, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 19, 53, 36, 0, DateTimeKind.Unspecified) },
                    { "588f624b-fb47-467b-a8f0-f34f7fa7aba9", "{ \"columns\": [ \"Ecem Hatice Akova\", \"Dalay Derya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 32, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 21, 54, 30, 0, DateTimeKind.Unspecified) },
                    { "ad10b1df-a8b2-4020-96fe-f3c571ea6db2", "{ \"columns\": [ \"Büşra Gül Altundal\", \"İbrahim Alp Tekin Ege\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 15, 13, 58, 0, DateTimeKind.Unspecified) },
                    { "f9e3b66b-cba4-476b-bf01-c7952b1e0078", "{ \"columns\": [ \"Ahmet Raşit Akoğuz\", \"Tubanur Dereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 14, 11, 0, DateTimeKind.Unspecified) },
                    { "eea0e2e6-c811-498f-be76-b011bd1e25c5", "{ \"columns\": [ \"Ahmet Polat Aklar Çörekçi\", \"Alya Denizgünü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 3, 37, 0, DateTimeKind.Unspecified) },
                    { "c207313b-10d8-4e63-8725-72079ea437be", "{ \"columns\": [ \"Atahan Adanır\", \"Ozan Ege Çomu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 16, 35, 59, 0, DateTimeKind.Unspecified) },
                    { "16e16edf-e157-4eeb-831a-cca47e622d29", "{ \"columns\": [ \"Hacı Mehmet Adıgüzel\", \"Hilal Ebru Çonay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 10, 8, 37, 0, DateTimeKind.Unspecified) },
                    { "e069a6cb-1565-44a2-926d-505a1df51ee4", "{ \"columns\": [ \"Mükerrem Zeynep Ağca\", \"Ayben Çorumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 20, 19, 52, 0, 0, DateTimeKind.Unspecified) },
                    { "353c7399-8add-4824-9cf8-9bd0565c0f76", "{ \"columns\": [ \"Bestami Ağırağaç\", \"Abdulbaki Çotur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 0, 30, 39, 0, DateTimeKind.Unspecified) },
                    { "24a9495d-faf7-4b0a-9d5b-dcaaecb3d5d6", "{ \"columns\": [ \"Aykanat Ağıroğlu\", \"Neva Çuhadar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 6, 58, 40, 0, DateTimeKind.Unspecified) },
                    { "c7333440-e3fe-434f-bca7-4e1625b2df53", "{ \"columns\": [ \"Şennur Ağnar\", \"Öznur Çulhaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 15, 19, 12, 0, DateTimeKind.Unspecified) },
                    { "4d0ba356-8eff-4a2a-b8cf-43bf173fe04e", "{ \"columns\": [ \"Tutkum Ahmadı Asl\", \"Olgun Dadalıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "dca2113c-c14f-49bf-a385-44c1bb8ae4cc", "{ \"columns\": [ \"Mügenur Ahmet\", \"Çağrı Atahan Dağar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 9, 12, 7, 0, DateTimeKind.Unspecified) },
                    { "d7c45535-a041-4508-9169-8da5bfcda199", "{ \"columns\": [ \"Sevinç Ak\", \"Özalp Dağbağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 10, 36, 1, 0, DateTimeKind.Unspecified) },
                    { "f8bed38f-0d72-4724-82ea-279f97a2c602", "{ \"columns\": [ \"Kayıhan Nedim Akarcalı\", \"Hüsne Aysun Dal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 7, 40, 22, 0, DateTimeKind.Unspecified) },
                    { "086c78f1-d52a-4990-86ed-fc07f4abf188", "{ \"columns\": [ \"Fatma Özlem Acar\", \"Gürbüz Çivici\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 8, 37, 49, 0, DateTimeKind.Unspecified) },
                    { "1a8b435b-df7f-4750-8296-a7c51ada9a12", "{ \"columns\": [ \"Lemi Akarçay\", \"Aydonat Dalkılıç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 18, 53, 26, 0, DateTimeKind.Unspecified) },
                    { "0de47b27-2f0b-400b-8e72-b7f3cad43175", "{ \"columns\": [ \"Cihan Akarpınar\", \"Ezgin Dallı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 23, 23, 27, 0, DateTimeKind.Unspecified) },
                    { "88d71c60-1d85-4e23-b12b-001f762cf971", "{ \"columns\": [ \"Rafi Akaş\", \"Refiye Seda Dalyaprak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 0, 20, 26, 0, DateTimeKind.Unspecified) },
                    { "95966a06-eea6-492e-89c6-829ab353829c", "{ \"columns\": [ \"Mehmetcan Akay\", \"Esat Erdem Daniş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 59, 39, 0, DateTimeKind.Unspecified) },
                    { "8845e0c9-38cb-43d3-ac8b-a3fbceda3413", "{ \"columns\": [ \"Nuhaydar Akbilmez\", \"Ayşe Neslihan Daşdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 6, 32, 0, DateTimeKind.Unspecified) },
                    { "2bbebe96-0c29-4bc3-9389-3c0e84cf9281", "{ \"columns\": [ \"Emine Münevver Akca\", \"Fetullah Davutoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 52, 5, 0, DateTimeKind.Unspecified) },
                    { "d0cb53fc-a561-4ab4-828d-1b9d4b7eef35", "{ \"columns\": [ \"Servet Akçagunay\", \"Mert Görkem Dayıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 6, 22, 0, DateTimeKind.Unspecified) },
                    { "ff70c4fd-db68-41a9-9e7f-616f318097a5", "{ \"columns\": [ \"Çilem Akçay\", \"Ergün Değirmendereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "b4d991d9-418b-492f-bb5e-2740792c4726", "{ \"columns\": [ \"Recep Ali Samet Akdoğan\", \"Hülya Delı Chasan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 1, 28, 20, 0, DateTimeKind.Unspecified) },
                    { "db2a5181-3187-4071-83b1-dc1da17dd62b", "{ \"columns\": [ \"Emre Ayberk Akfırat\", \"Doga Elif Delice\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 23, 12, 45, 0, DateTimeKind.Unspecified) },
                    { "45f75151-0276-47c8-9b68-1dc4cd7d6091", "{ \"columns\": [ \"Kerime Hacer Akıllı\", \"Muhammed Bazit Deliloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 7, 7, 46, 0, DateTimeKind.Unspecified) },
                    { "0900029d-3ef5-4d19-8385-05a1e37b7bda", "{ \"columns\": [ \"Ercüment Akıncılar\", \"Miraç Demırören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 21, 16, 0, DateTimeKind.Unspecified) },
                    { "94d1f323-8374-405a-b402-64b7d1cc1e6c", "{ \"columns\": [ \"Sarper Akış\", \"Hürel Demiriz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 4, 13, 6, 0, DateTimeKind.Unspecified) },
                    { "6db62b3c-7dbd-4f10-af1b-a18e617f19da", "{ \"columns\": [ \"Berker Akkiray\", \"Sömer Demiroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 20, 15, 59, 13, 0, DateTimeKind.Unspecified) },
                    { "3fd63405-dc07-4d09-aa4b-c9e779dc4f32", "{ \"columns\": [ \"İclal Akkoyun\", \"Aysel Aysu Demirsatan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 1, 58, 53, 0, DateTimeKind.Unspecified) },
                    { "f79af452-ac48-4dae-b9a3-045918145aa0", "{ \"columns\": [ \"Lemis Akküt\", \"Mehmet Kemal Dengizek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 20, 51, 9, 0, DateTimeKind.Unspecified) },
                    { "cf1ca719-067b-4640-878f-0b9bf6f2268d", "{ \"columns\": [ \"Ata Kerem Akman\", \"Zeynep Büşra Derdemez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 0, 27, 12, 0, DateTimeKind.Unspecified) },
                    { "d0f0c757-f168-4713-afd2-3610cca5ee1c", "{ \"columns\": [ \"Erna Aluç\", \"Güngör Erkin Egeli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 61, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 15, 53, 4, 0, DateTimeKind.Unspecified) },
                    { "be22442a-acc6-4426-b2af-154b705ca3ed", "{ \"columns\": [ \"Hikmet Nazlı Alver\", \"Çağın Egin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 62, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "5057331d-3d97-4d80-92ad-e4f0d93281ad", "{ \"columns\": [ \"İsmail Umut Anık\", \"Alphan Ekercan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 63, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 1, 18, 30, 0, DateTimeKind.Unspecified) },
                    { "576f1b37-ef27-405e-919d-bf755a9ed657", "{ \"columns\": [ \"Murat Kaan Ayanoglu\", \"Belin Esendemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 96, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 22, 22, 54, 0, DateTimeKind.Unspecified) },
                    { "ea4d97b6-1550-4ef3-9a66-9696787dfc0e", "{ \"columns\": [ \"Murat Sinan Ayaz\", \"Rukiye Esgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 97, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 23, 4, 53, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "a4c912a9-74b6-4e69-94fb-f4eb42c055f5", "{ \"columns\": [ \"Ateş Aycı\", \"İslam Eshaqzada\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 98, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 14, 29, 28, 0, DateTimeKind.Unspecified) },
                    { "9b525e5a-ff7d-4716-b15b-ca8c0ced353e", "{ \"columns\": [ \"Zeynep Nihan Aydınlıoğlu\", \"Batıray Eski\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 99, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 23, 50, 9, 0, DateTimeKind.Unspecified) },
                    { "b2b143e2-ccae-488c-a900-4d43196ba92a", "{ \"columns\": [ \"Kerime Aydoğan Yozgat\", \"Süheyl Esvap\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 19, 34, 0, DateTimeKind.Unspecified) },
                    { "cbca5f2a-ddc7-46a2-ace0-e1181cb466dc", "{ \"columns\": [ \"Hami Aydoğdu\", \"Yargı Yekta Eşe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 101, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 14, 36, 11, 0, DateTimeKind.Unspecified) },
                    { "c65e2ac0-08a1-42aa-a1b0-17b19458a9f2", "{ \"columns\": [ \"Thomas Aygen\", \"Elzem Evrenos\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 102, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 3, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "8fe042a8-c998-4d48-9191-c39ab10a5307", "{ \"columns\": [ \"Güneş Aykan\", \"Ilgaz Eyipişiren\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 103, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 22, 51, 0, DateTimeKind.Unspecified) },
                    { "d22f698c-ce8e-48a1-95d0-0b6fb36729ae", "{ \"columns\": [ \"Elif Feyza Ayrım\", \"Ongar Eyyupoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 104, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 15, 3, 26, 0, DateTimeKind.Unspecified) },
                    { "3f77a59c-cd01-4675-ae55-5733f69f31d1", "{ \"columns\": [ \"Uğur Ali Aysal\", \"Faik Ezber\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 105, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 10, 41, 0, DateTimeKind.Unspecified) },
                    { "05d718bd-baa5-4bc6-ba3f-39354d5dff0b", "{ \"columns\": [ \"Osman Yasin Aysan\", \"Turan Fahri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 106, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 40, 27, 0, DateTimeKind.Unspecified) },
                    { "64593604-1d7f-4cd5-b916-3e41a6824cc4", "{ \"columns\": [ \"Adem Ayvacık\", \"Okbay Fatih\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 107, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 33, 16, 0, DateTimeKind.Unspecified) },
                    { "bc215627-cd46-4151-b485-503951e75e65", "{ \"columns\": [ \"Sera Cansın Azbay\", \"Latife Fatin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 108, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 16, 54, 51, 0, DateTimeKind.Unspecified) },
                    { "a22bcbb7-128c-43ff-af6f-136909ed88ec", "{ \"columns\": [ \"Ali İsmail Babacan\", \"Eyüp Orhun Fındık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 109, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 48, 48, 0, DateTimeKind.Unspecified) },
                    { "df2da36e-9a36-44d5-a50f-468666e9a6ef", "{ \"columns\": [ \"Ruhugül Babadostu\", \"İrfan Anıl Fındıkçı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 110, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 18, 42, 0, DateTimeKind.Unspecified) },
                    { "af46784b-794b-4190-b6d7-eacb167fb2a1", "{ \"columns\": [ \"Alçiçek Bad\", \"Ertuğ Furuncuoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 111, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 13, 30, 15, 0, DateTimeKind.Unspecified) },
                    { "3a2fd920-4b68-4a5d-b11c-37ee4fe7556d", "{ \"columns\": [ \"Memet Bağcı\", \"Berhudan Garip\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 112, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 18, 14, 59, 0, DateTimeKind.Unspecified) },
                    { "61400350-84b6-48ed-80c2-6aaacdb8b4e4", "{ \"columns\": [ \"Mercan Bağçivan\", \"Nihan Gazitepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 113, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 11, 28, 35, 0, DateTimeKind.Unspecified) },
                    { "d45f92cf-613e-4cf4-b1b7-04650a2f0710", "{ \"columns\": [ \"Gökay Bağış\", \"Menekşe Geben\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 114, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 21, 17, 54, 0, DateTimeKind.Unspecified) },
                    { "c5cf43bb-cce7-4a0a-ae94-ab9fd80b2f5b", "{ \"columns\": [ \"Pırıltı Bahçeli\", \"Şeniz Geboloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 115, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 13, 24, 53, 0, DateTimeKind.Unspecified) },
                    { "674b8932-123c-41d3-9276-3a0660991e93", "{ \"columns\": [ \"Özgün Bahtıyar\", \"Zeynep Senahan Geçioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 116, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 13, 8, 53, 0, DateTimeKind.Unspecified) },
                    { "36f108a0-f8ab-4558-9b7f-8799f6c3e91a", "{ \"columns\": [ \"Özgen Baka\", \"Hayri Anıl Geçkin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 117, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 22, 39, 0, 0, DateTimeKind.Unspecified) },
                    { "fdbda477-7fe6-4ed2-a6e7-9fd490712771", "{ \"columns\": [ \"Seung Hun Baki\", \"Muazzez Ece Gemalmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 118, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 24, 30, 0, DateTimeKind.Unspecified) },
                    { "60a26cb3-5d72-4522-8054-71c4111753e4", "{ \"columns\": [ \"Gülser Bal\", \"Kerem Cahit Gençoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 119, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 17, 38, 4, 0, DateTimeKind.Unspecified) },
                    { "15da7459-c592-41b6-9cc3-c3fbbe4880af", "{ \"columns\": [ \"Yüksel Balcı\", \"Sadık Can Gezmiş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 120, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 3, 41, 25, 0, DateTimeKind.Unspecified) },
                    { "5e013f3c-a561-4182-b64f-29736f795a88", "{ \"columns\": [ \"Ecren Baldo\", \"Resmiye Elif Gırgın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 121, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 32, 20, 0, DateTimeKind.Unspecified) },
                    { "758250f6-409a-473c-9ba0-33395dc1c1c1", "{ \"columns\": [ \"Muhammet Raşit Balı\", \"Nergiz Gilim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 122, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 17, 3, 38, 0, DateTimeKind.Unspecified) },
                    { "f8b3c96c-2984-4f4a-8755-9f00a29b0804", "{ \"columns\": [ \"Kaan Muharrem Ay\", \"Lütfiye Sena Esen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 95, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 16, 42, 17, 0, DateTimeKind.Unspecified) },
                    { "a59e45f3-66f7-4788-8156-bbbb053ecede", "{ \"columns\": [ \"Nehar Avşar\", \"Neslihan Buşra Esat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 94, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 14, 25, 47, 0, DateTimeKind.Unspecified) },
                    { "033061f5-40cc-4bc8-8932-f78f7c059d1d", "{ \"columns\": [ \"Saime Avıandı\", \"Arslan Erzurumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 93, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 7, 31, 25, 0, DateTimeKind.Unspecified) },
                    { "7a1521d9-eeb4-4af5-b6d3-8002b3a14f70", "{ \"columns\": [ \"Almina Avcı Özsoy\", \"Tunca Eryılmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 92, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 14, 28, 53, 0, DateTimeKind.Unspecified) },
                    { "e9a959d9-0d2f-4c18-8b29-9861e0fdad92", "{ \"columns\": [ \"İlkay Ramazan Ankara\", \"Lale Ekrem\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 64, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 7, 47, 0, DateTimeKind.Unspecified) },
                    { "3ed9c8d3-1930-4d57-bd43-58ae148626dc", "{ \"columns\": [ \"Nebahat Ansen\", \"Bağış Can Elbaşı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 12, 57, 54, 0, DateTimeKind.Unspecified) },
                    { "0fdfd441-1321-4206-8cbe-b7b2c6c82aa1", "{ \"columns\": [ \"İlyas Umut Apul\", \"Mert Cem Eliçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 66, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 13, 19, 43, 0, DateTimeKind.Unspecified) },
                    { "6cbfef24-66ec-4c81-8477-882a0d02d7b1", "{ \"columns\": [ \"Halim Aral\", \"Ahmet Sencer Emikoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 67, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 34, 17, 0, DateTimeKind.Unspecified) },
                    { "3dbe8f01-358f-485b-9858-30d48eb7d2a3", "{ \"columns\": [ \"Yasin Şükrü Arap\", \"Akife Erbay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 68, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 16, 16, 45, 0, DateTimeKind.Unspecified) },
                    { "59ec1d4a-7fb8-4609-bcaa-f986c74455a5", "{ \"columns\": [ \"Cansev Arat\", \"Burç Erbil\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 69, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 18, 50, 0, 0, DateTimeKind.Unspecified) },
                    { "e7560618-3236-4d7f-83c3-668bfc37056d", "{ \"columns\": [ \"Memet Ali Ardıç\", \"Nadire Erbul\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 18, 41, 29, 0, DateTimeKind.Unspecified) },
                    { "34e41298-0bb5-4338-9d3c-f4b75513f022", "{ \"columns\": [ \"Deniz Dilay Arıcan\", \"Hüseyin Zeyd Ercoşkun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 71, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 18, 31, 11, 0, DateTimeKind.Unspecified) },
                    { "8b3f6b0e-e169-47dc-a674-19054b5c8367", "{ \"columns\": [ \"İzlem Arınç\", \"Aynur Gül Ercüment\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 72, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 7, 54, 1, 0, DateTimeKind.Unspecified) },
                    { "c06e030b-1269-4605-83dd-178ad4248be6", "{ \"columns\": [ \"Öget Arif\", \"Samed Erek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 73, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 14, 42, 43, 0, DateTimeKind.Unspecified) },
                    { "abb39a17-85ff-4044-88ad-fe8fbc59cb2b", "{ \"columns\": [ \"Şeyda Nur Arikan\", \"Cem Ozan Erim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 74, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 21, 7, 38, 18, 0, DateTimeKind.Unspecified) },
                    { "bf3c9138-e43a-4edd-bd60-1c51f757a456", "{ \"columns\": [ \"Zeki Yiğithan Armutcu\", \"Bahar Cemre Erin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 2, 23, 47, 0, DateTimeKind.Unspecified) },
                    { "f3a687be-899d-46c4-b4f7-69c9bf913df5", "{ \"columns\": [ \"Nunazlı Arpacı\", \"Rekin Erkek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 76, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 20, 42, 49, 0, DateTimeKind.Unspecified) },
                    { "d3e415ea-c7ec-4563-bb5e-9ead65a1aa1f", "{ \"columns\": [ \"Kazım Balta\", \"Mehmetali Girgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 124, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 21, 17, 0, DateTimeKind.Unspecified) },
                    { "a82c834a-be49-44c0-96bd-71427691ad09", "{ \"columns\": [ \"Ferdacan Aruca\", \"Hüseyin Serkan Erkekli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 77, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 11, 5, 27, 0, DateTimeKind.Unspecified) },
                    { "fbb91322-26b7-498f-b6ec-7225bbe01ca1", "{ \"columns\": [ \"Mustafa Burhan Askın\", \"Beniz Erkmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 79, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 3, 6, 59, 0, DateTimeKind.Unspecified) },
                    { "2afa7b31-a7fe-4ebe-97cd-6b8f7c6236d8", "{ \"columns\": [ \"Ilım Aslantürk\", \"Hasan Burak Erkoç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "b1922515-c0af-4d3b-9d24-684fe72efbe6", "{ \"columns\": [ \"Sevginur Aşcı\", \"Selman Erkoşan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 81, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 10, 44, 52, 0, DateTimeKind.Unspecified) },
                    { "2e85c51e-4d64-45c2-889d-f50ed228a04c", "{ \"columns\": [ \"Hayrunnisa Aşveren\", \"Hanife Nur Erkovan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 82, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 7, 4, 7, 0, DateTimeKind.Unspecified) },
                    { "f66ad067-9a75-4258-9003-28fb667e4ee6", "{ \"columns\": [ \"Hanife Duygu Ata\", \"Alper Emin Erkuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 83, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 21, 9, 39, 27, 0, DateTimeKind.Unspecified) },
                    { "7aa89416-4506-4371-8824-857902473b6f", "{ \"columns\": [ \"Sevtap Atan\", \"Elif Kevser Eroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 84, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 16, 27, 28, 0, DateTimeKind.Unspecified) },
                    { "09f5e0d9-4b3f-4a72-8609-b847fc87ca94", "{ \"columns\": [ \"Paksoy Ateş\", \"Abdullah Mert Erol\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 85, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 13, 55, 21, 0, DateTimeKind.Unspecified) },
                    { "9ff2d9c8-3bed-4ce2-aac9-4cd1edd0e556", "{ \"columns\": [ \"İlkim Ateşcan\", \"Çisel Ersin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 86, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 15, 18, 22, 0, DateTimeKind.Unspecified) },
                    { "90190534-4a49-4410-b129-fb4ecd495f6c", "{ \"columns\": [ \"Rubabe Gökçen Atlı\", \"İlkin Ersöz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 87, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 20, 11, 52, 0, DateTimeKind.Unspecified) },
                    { "5ea32777-1646-4d61-a54e-7780cecaacbe", "{ \"columns\": [ \"Saba Atmaca\", \"Cantekin Erten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 88, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 21, 8, 1, 0, DateTimeKind.Unspecified) },
                    { "59b28cf6-e360-4027-8149-c6ded451a115", "{ \"columns\": [ \"Çisem Atok\", \"Onur Kerem Ertepınar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 89, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 18, 8, 13, 0, DateTimeKind.Unspecified) },
                    { "5337d0d4-098d-4cc7-9cf6-7e714b518fd7", "{ \"columns\": [ \"Sabiha Elvan Atol\", \"İsmail Enes Eruzun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 90, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 19, 58, 20, 0, DateTimeKind.Unspecified) },
                    { "4425a131-da4a-47c5-92da-cd630ed72437", "{ \"columns\": [ \"Edip Attila\", \"Hamıd Eryıldız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 91, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 1, 5, 35, 0, DateTimeKind.Unspecified) },
                    { "d80e7dab-9339-4e1a-af33-3ff273a99f10", "{ \"columns\": [ \"Şerife Asil\", \"İbrahim Candaş Erki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 78, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 14, 44, 48, 0, DateTimeKind.Unspecified) },
                    { "afcc3053-5788-438c-9e02-d523f54ab97a", "{ \"columns\": [ \"Seher İrem Çitfçi\", \"Naci Karakaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 249, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 2, 32, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                table: "Settings");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "01729788-a599-4699-9ee8-3cd78fb52ebd");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "033061f5-40cc-4bc8-8932-f78f7c059d1d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "037514f5-096b-4c3d-9b40-0b660efda066");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "03c26518-c956-404c-9515-cb3d5046baee");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "05d718bd-baa5-4bc6-ba3f-39354d5dff0b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "062bd780-ee68-4870-83eb-c536d44a70db");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "086c78f1-d52a-4990-86ed-fc07f4abf188");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0900029d-3ef5-4d19-8385-05a1e37b7bda");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "09f5e0d9-4b3f-4a72-8609-b847fc87ca94");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0a6d7ea5-b0be-4888-9ab8-196588486076");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0c08ac40-9327-4671-b595-afd4f54e13db");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0de47b27-2f0b-400b-8e72-b7f3cad43175");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0f2e5292-efb7-4e7b-8f5c-983d30a6195a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0fd97f2b-cbd5-4b4e-a743-a462a1173a99");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "0fdfd441-1321-4206-8cbe-b7b2c6c82aa1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "12403480-ab7d-473b-8b8f-efe5eb4dccfd");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "13d8d003-91e5-4b0a-bfd2-35892f922dc0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "151481cf-d82f-46ec-914f-eedd165e34ff");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "15da7459-c592-41b6-9cc3-c3fbbe4880af");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "16e16edf-e157-4eeb-831a-cca47e622d29");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1791660b-4af2-4251-9df3-e73aa06319c5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "17bb519e-0eae-4125-bebb-a308f96bf958");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "189718b9-bb4b-4256-8492-899f515a24be");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1921dc60-c487-4c41-a8d0-ec66ce19e4c7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "19dde402-9b05-40c1-a79f-3d7947ef4f20");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1a332232-fdfa-4faa-bf5d-14508165e2dd");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1a8b435b-df7f-4750-8296-a7c51ada9a12");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1c5ce163-25bb-4e19-a431-96a19f0abc16");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1e6710a7-7889-4188-807d-621a62dd7ff3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1eea15c6-fe75-4fcb-af8c-dec451f7f709");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "1f165671-895c-4f84-8806-626b19a5f29c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "208e3912-ca8d-4bb1-b6e8-eea84077a1ae");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "221c072c-5683-45f6-a1ed-7c9b15f2f0df");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "24a9495d-faf7-4b0a-9d5b-dcaaecb3d5d6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "252f415e-25ad-429d-b710-4e1b95887543");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "28844d9e-25b2-4177-bbec-5ee0074325c6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2afa7b31-a7fe-4ebe-97cd-6b8f7c6236d8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2bbebe96-0c29-4bc3-9389-3c0e84cf9281");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2bca9439-1e31-4bd3-959a-38f053201bc6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2c14f419-8985-4aab-9303-3145cf4d7e94");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2c223878-fc58-4580-81b6-691cdf878986");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2e3cd26d-fabd-4071-85a7-a488fba77f03");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "2e85c51e-4d64-45c2-889d-f50ed228a04c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "34e41298-0bb5-4338-9d3c-f4b75513f022");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3524e982-e5cd-4a45-863d-6af92ba8f246");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "353c7399-8add-4824-9cf8-9bd0565c0f76");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "35c94a0d-73e7-4d70-a774-bc8835ab4c01");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3677c192-8d30-4a0f-9acb-5b53919f7e2f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "36f108a0-f8ab-4558-9b7f-8799f6c3e91a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3940c165-8a5c-44fa-9117-81761cb788da");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3a2fd920-4b68-4a5d-b11c-37ee4fe7556d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3dbe8f01-358f-485b-9858-30d48eb7d2a3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3e6fb6a1-763a-437d-bacf-89b2cd0f1dc4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3ed9c8d3-1930-4d57-bd43-58ae148626dc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3f77a59c-cd01-4675-ae55-5733f69f31d1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "3fd63405-dc07-4d09-aa4b-c9e779dc4f32");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "41f7830a-b288-45cd-a3eb-4a35a02bf7b1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "422b62ce-8608-406a-b516-03bc3979139d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4425a131-da4a-47c5-92da-cd630ed72437");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4431ab0f-f631-4ca2-82b9-b1ff373dfa80");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "45068c94-7d37-463f-817e-6e7c6aa60a93");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "45f75151-0276-47c8-9b68-1dc4cd7d6091");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4655cbff-16aa-4f11-be49-1a83ff7c71a2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "48d26b9b-4e5f-4008-b7f1-feabd9cae090");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "49cf63b6-7379-403b-be0c-06236922f71b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4b832fc9-ecd7-4bbb-a3d8-7ef5fc6175a0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4c48f469-5fd6-45bc-8ef2-f9b19f141d12");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4d0ba356-8eff-4a2a-b8cf-43bf173fe04e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4d66b847-fddf-44f8-a4af-e6c9d3481861");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4de104b2-dc84-47b3-b20b-561b611190e9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4f0d10f0-f489-402d-a2da-4ced4ae12638");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "4fcaf09f-c451-446c-b185-236268905dff");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5057331d-3d97-4d80-92ad-e4f0d93281ad");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "526f1b34-8a53-41ed-a18a-876db5ab33bf");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5337d0d4-098d-4cc7-9cf6-7e714b518fd7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "576f1b37-ef27-405e-919d-bf755a9ed657");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "588f624b-fb47-467b-a8f0-f34f7fa7aba9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "59b28cf6-e360-4027-8149-c6ded451a115");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "59ec1d4a-7fb8-4609-bcaa-f986c74455a5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5c2bf23f-c5fd-4486-bd96-890afb5ff353");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5d80a530-eb23-49f0-9ed1-0726b2b6b02a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5e013f3c-a561-4182-b64f-29736f795a88");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "5ea32777-1646-4d61-a54e-7780cecaacbe");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "606f0813-40dc-4284-bacd-f29ca18ff083");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "60a26cb3-5d72-4522-8054-71c4111753e4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "61400350-84b6-48ed-80c2-6aaacdb8b4e4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "61d2a475-2e80-43e3-912a-fc6da7f0eb9a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6316ae19-fee2-4b07-85d1-fd257b40c0c9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "63bd2028-e743-47c0-ba47-a90ccee3b6ac");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "63c1ca55-fa66-44dd-b319-76274ad734b5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "643cedd3-de1a-4835-9ee8-1ea444d4eff7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "64593604-1d7f-4cd5-b916-3e41a6824cc4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "664e2050-bccd-4c76-ab96-f2bd10c7a45f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "67003735-f8f9-4022-baf2-d5687f9484ed");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "674b8932-123c-41d3-9276-3a0660991e93");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6866a7cd-140d-4eb2-943e-4abfd30bc9e8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "693b5459-f281-47f3-9189-684fc6fe3b13");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "693b6753-b0ab-4492-8bed-bea23bc2595f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6a7a984b-d75e-452d-af09-7afc36b52c0f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6ad58fc1-13f2-4110-8987-186e6516bf10");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6b932980-e2a0-4ca0-811f-32817dd70f9e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6cbfef24-66ec-4c81-8477-882a0d02d7b1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6cc859c3-623f-432a-bf86-03fb9a45f2cd");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "6db62b3c-7dbd-4f10-af1b-a18e617f19da");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "708f0ccf-19ab-462d-b7fd-2a96d7004dc4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "70f5f963-7083-43ab-952b-eaca92eabda0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7168264a-8593-47a8-841b-a6de940f94a1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "72c7e9d1-0e14-41a4-9a3d-6b50fa8bfed6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7578590e-8c05-498b-8986-0ce257f39299");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "758250f6-409a-473c-9ba0-33395dc1c1c1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "760f8904-2e8a-43b2-81ec-9da085ee008c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "765df94b-44c8-423d-a9f8-1d0b5acc48a8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "778df9b4-659f-41bc-8e90-0eed41c882e0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7a1521d9-eeb4-4af5-b6d3-8002b3a14f70");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7a8532ed-336c-4dab-a3f5-b46aa74fdc55");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7aa89416-4506-4371-8824-857902473b6f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7bb80287-bd85-4896-bea8-36066dc2f5c0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7c1810ef-fb34-40f0-b3a6-8b70a47e2e06");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7c84ed49-11e4-4c83-b93b-26deab405cff");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7ca49436-0cc4-44cb-883f-9dffbd505414");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "7d9fc424-1422-4241-b63e-df0b1f51be3b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "80a36603-441f-41b3-8d34-8eeaab302948");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "812a10c8-1420-456d-aeb9-26051b01962f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8146c340-75dc-452c-85a6-5c04382dcc74");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8273403f-40c0-4763-b155-ed5a44a7ab35");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8348e57a-009a-4ed6-8b5e-c3d530b0e022");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "83a87992-aac6-48c2-ba3b-daeed892ed56");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "840aa840-0b21-41c1-86e3-768072a3177c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "85f17799-1694-4d04-9203-00137c3ec91f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "86dc8169-3a2c-4b54-9704-487111777e27");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "86dd5757-026b-4a7b-bf42-6c14a4de8326");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8845e0c9-38cb-43d3-ac8b-a3fbceda3413");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "88d71c60-1d85-4e23-b12b-001f762cf971");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8b3f6b0e-e169-47dc-a674-19054b5c8367");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8c457ca6-80b2-48e8-9935-783d23a48a91");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8d07555e-74aa-4d1d-8160-2a6db235665e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8db8c236-c51a-4d50-a19c-cd80b2751f3e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8e77d790-c62e-4e0a-b063-3e8992c105db");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8f7a5331-1856-4596-bffe-bf912ff9d4fa");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8fcf5306-220d-49e9-bbe0-01da2cac167c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "8fe042a8-c998-4d48-9191-c39ab10a5307");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "90190534-4a49-4410-b129-fb4ecd495f6c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "904af133-216f-477e-8ede-be520ee9e980");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "91e384a2-8c9e-4e7f-8ec6-7e0b09112900");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "94d1f323-8374-405a-b402-64b7d1cc1e6c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "94ec00d2-f79d-4036-ab62-95b87769af55");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9505cb80-688c-41ad-977c-70c43e1d0a4c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "95966a06-eea6-492e-89c6-829ab353829c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "96b3fc37-4858-4a73-ac7c-0231293a7931");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "96c7dac3-8795-473c-9e93-8b5779912627");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "98f21f85-e9b0-4085-80df-1cd47856ab48");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9ac9b38b-d42d-4030-a4ac-18bb4bf00867");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9b525e5a-ff7d-4716-b15b-ca8c0ced353e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9c6c3138-4a90-449d-8a9e-2e224061af2a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9cd13332-2e7d-44a2-9f58-11207cf2afd3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9f762187-bc3e-4d3e-833a-5526ac18f3d3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "9ff2d9c8-3bed-4ce2-aac9-4cd1edd0e556");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a13c037e-5a8c-46c2-b98a-14a93b219ee8");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a1ecdcef-71a9-4133-813e-f035fb2bf4da");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a22bcbb7-128c-43ff-af6f-136909ed88ec");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a4c912a9-74b6-4e69-94fb-f4eb42c055f5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a4ff2ca1-f301-42a6-b53a-0caf924164f7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a59e45f3-66f7-4788-8156-bbbb053ecede");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a7896a0d-bda3-4e04-a993-3626357e53bc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a82c834a-be49-44c0-96bd-71427691ad09");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "a83a12ad-99b1-486d-b117-56ddf6260d53");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "abb39a17-85ff-4044-88ad-fe8fbc59cb2b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ad10b1df-a8b2-4020-96fe-f3c571ea6db2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ae6885b0-37cf-4482-8866-f95dffc2ab7b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "af46784b-794b-4190-b6d7-eacb167fb2a1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "afcc3053-5788-438c-9e02-d523f54ab97a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b1922515-c0af-4d3b-9d24-684fe72efbe6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b29e6293-78e1-47f5-baf1-1fddcb043d53");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b2b143e2-ccae-488c-a900-4d43196ba92a");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b42087a1-1827-47b7-9de8-4ca238b086d5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b4674279-cead-4319-ac3b-2454864e6c49");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b4c4df06-edca-4a7a-a574-0a165b2aa77e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b4d991d9-418b-492f-bb5e-2740792c4726");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b681e880-4052-403e-8b93-1103c6b5fc86");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b88591a5-93b4-4349-a8d3-bc3d7753438b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "b9d206c8-89b8-41fc-a8be-744e4c8df80f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bc215627-cd46-4151-b485-503951e75e65");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "be22442a-acc6-4426-b2af-154b705ca3ed");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "be74478e-9caf-4323-a37a-d16861edb88f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "bf3c9138-e43a-4edd-bd60-1c51f757a456");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c06e030b-1269-4605-83dd-178ad4248be6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c207313b-10d8-4e63-8725-72079ea437be");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c5cf43bb-cce7-4a0a-ae94-ab9fd80b2f5b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c65e2ac0-08a1-42aa-a1b0-17b19458a9f2");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c6d7859e-d59c-4415-b687-0facbe6ef73d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c6e6d8bb-7b16-46ca-a8de-ad85fda87fdf");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c7333440-e3fe-434f-bca7-4e1625b2df53");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "c8ea198d-0dfe-4921-b7fd-185eb064c093");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "cbca5f2a-ddc7-46a2-ace0-e1181cb466dc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "cc8be8d8-90ba-4565-8733-f770258afecf");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "cf1ca719-067b-4640-878f-0b9bf6f2268d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d0cb53fc-a561-4ab4-828d-1b9d4b7eef35");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d0f0c757-f168-4713-afd2-3610cca5ee1c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d22f698c-ce8e-48a1-95d0-0b6fb36729ae");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d281f897-9306-4eb1-aa6a-84dd8f15d7cf");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d3e415ea-c7ec-4563-bb5e-9ead65a1aa1f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d45f92cf-613e-4cf4-b1b7-04650a2f0710");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d4ab796e-9472-4cbd-bd3f-c34a6e7337d1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d76c7f85-3b30-484a-9f5a-e705dbfe0ced");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d7c45535-a041-4508-9169-8da5bfcda199");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d80e7dab-9339-4e1a-af33-3ff273a99f10");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d8f39db6-4177-4852-83c3-2ca7d06efc11");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d91155ea-300a-4078-87a0-ba796a4d8f1e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d97dd9a5-0990-4d6f-b086-e0559b30c30d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "d9c3a423-70ef-4bf2-9688-0e28c4c07508");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "db2a5181-3187-4071-83b1-dc1da17dd62b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dca2113c-c14f-49bf-a385-44c1bb8ae4cc");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dccbadbd-e325-4cc4-a031-7909cc691f4f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dd630381-54e3-45ef-b308-01fb17cc985e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "dd9e1941-aeb4-4117-a8ef-6ba5a47b8747");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "df2da36e-9a36-44d5-a50f-468666e9a6ef");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "df3b062a-4433-469e-90a4-dc13a9a4670b");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e069a6cb-1565-44a2-926d-505a1df51ee4");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e568442b-ea2c-4dc9-afde-29eaa33c76d7");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e7560618-3236-4d7f-83c3-668bfc37056d");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e793d4e8-79c3-42b1-b7ae-8c6cd335c46e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e79806be-9a1d-43c2-9fde-5cd6865802db");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "e9a959d9-0d2f-4c18-8b29-9861e0fdad92");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ea4d97b6-1550-4ef3-9a66-9696787dfc0e");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eaba0fa5-7216-4284-952a-0da1023f73ce");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eb554fe7-8b5e-4064-9cbc-945e1af9a49c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ee4401e3-f4c3-4351-8968-000078f9068c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "eea0e2e6-c811-498f-be76-b011bd1e25c5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f0af717f-efcd-46a8-b434-17db63c8a9c5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f2290b25-322b-4104-84b6-2b4e2ff3b947");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f30dda98-24cb-46b6-9690-f8354253e3d9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f3a687be-899d-46c4-b4f7-69c9bf913df5");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f516af08-a32c-41a9-8afb-ef628966e7ef");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f66ad067-9a75-4258-9003-28fb667e4ee6");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f79af452-ac48-4dae-b9a3-045918145aa0");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f8b3c96c-2984-4f4a-8755-9f00a29b0804");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f8bed38f-0d72-4724-82ea-279f97a2c602");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f9e3b66b-cba4-476b-bf01-c7952b1e0078");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "f9f14cbf-98a3-4ad6-a776-409af2d482c3");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fa225794-f976-468f-ad42-c097df119e4c");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fa4126c5-0a2e-47cb-88ac-f41eae8e8e03");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fb0db6ab-1776-478a-abf7-4ab9dd79bbba");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fb8ea99e-eb1f-48c9-82dc-1f9749f72cb9");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fbb91322-26b7-498f-b6ec-7225bbe01ca1");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fc8a8e4d-fd67-45aa-aa8f-94caf55db501");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fcfd2ea3-46b9-4c58-892e-ebb0eda3eb40");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fdbda477-7fe6-4ed2-a6e7-9fd490712771");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "fecbb456-991b-4b95-937e-ffbb9646746f");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: "ff70c4fd-db68-41a9-9e7f-616f318097a5");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Settings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                table: "Settings",
                column: "Key");

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "23254e71-36c6-4eb8-9195-d7a2e264d5c9", "{ \"columns\": [ \"Özde Acarkan\", \"Zülal Çolak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 22, 15, 31, 0, DateTimeKind.Unspecified) },
                    { "d1b8c991-3d8f-4e83-b7fe-a7d93cbcf9d6", "{ \"columns\": [ \"Halime Beydağ\", \"Melek Diler Günel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 158, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 7, 27, 34, 0, DateTimeKind.Unspecified) },
                    { "9ba8f657-f83a-4819-a2b4-aaebe297f5a3", "{ \"columns\": [ \"Didem Bıçaksız\", \"Argun Güneri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 159, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 59, 8, 0, DateTimeKind.Unspecified) },
                    { "26afbac6-bd2f-4de1-a932-53e054d724d0", "{ \"columns\": [ \"Mihrinaz Bilal\", \"Mehmet Yekta Güneyi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 160, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 10, 9, 50, 0, DateTimeKind.Unspecified) },
                    { "3a69650d-a2af-443b-942d-d0d130d53aa4", "{ \"columns\": [ \"Lal Bilgeç\", \"Yasemin Erva Güntek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 161, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 51, 53, 0, DateTimeKind.Unspecified) },
                    { "83a79895-d4dd-4bae-befd-a83c98f94f1d", "{ \"columns\": [ \"Senay Bilgen\", \"Günan Güral\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 162, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 4, 59, 42, 0, DateTimeKind.Unspecified) },
                    { "32b3baa8-9396-4c69-a524-e331808114a1", "{ \"columns\": [ \"Remzi Bilgi\", \"Osman Cihan Gürdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 163, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 20, 19, 59, 0, DateTimeKind.Unspecified) },
                    { "9286da5b-fad8-4fbb-933c-5f29694877ed", "{ \"columns\": [ \"Armağan Bilgiç\", \"Okyanus Gürel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 164, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 5, 27, 45, 0, DateTimeKind.Unspecified) },
                    { "48661235-23db-41b3-93c6-272a7e2b39ab", "{ \"columns\": [ \"Çelik Bilgir\", \"Mert Alican Güreş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 165, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 10, 59, 36, 0, DateTimeKind.Unspecified) },
                    { "db780c99-350c-4935-b497-1e6437644810", "{ \"columns\": [ \"Kübra Tansu Bilgit\", \"Zeynep Doğa Gürses\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 166, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 17, 51, 8, 0, DateTimeKind.Unspecified) },
                    { "710900a7-8735-4607-b657-24367efac23f", "{ \"columns\": [ \"Uluç Emre Binbay\", \"Tarık Güven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 167, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 15, 15, 26, 0, DateTimeKind.Unspecified) },
                    { "2d78b917-fdeb-46f8-abd9-1548bfbe7638", "{ \"columns\": [ \"Mehmet Buğrahan Birgili\", \"Birgen Güvener\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 168, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 16, 22, 55, 0, DateTimeKind.Unspecified) },
                    { "3e70b752-54b3-4d78-acee-c505004784bb", "{ \"columns\": [ \"Doğuşcan Biriz\", \"Ahmet Korhan Güzel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 169, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 5, 25, 15, 0, DateTimeKind.Unspecified) },
                    { "20d1a506-ade1-4c87-96d3-b5ca19ace887", "{ \"columns\": [ \"Altan Boy\", \"Manolya Güzeller\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 170, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 12, 32, 18, 0, DateTimeKind.Unspecified) },
                    { "6141eeb4-e9d0-4cb4-ad0f-615d52fe8e5b", "{ \"columns\": [ \"Bengisu Boya\", \"Mustafa Berkay Güzeloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 171, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 14, 13, 55, 0, DateTimeKind.Unspecified) },
                    { "071c055b-1640-4693-9014-1486f6d48c71", "{ \"columns\": [ \"Onur Taylan Boylu\", \"Mehmet Anıl Hacıalioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 172, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 3, 34, 43, 0, DateTimeKind.Unspecified) },
                    { "2cbb9491-3fa6-4dc8-a12b-e17fe1d2af8a", "{ \"columns\": [ \"Ayseren Boyuktaş\", \"Ahmet Furkan Hacılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 173, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 19, 1, 9, 0, DateTimeKind.Unspecified) },
                    { "8ec0c55f-6900-4fcc-95fc-464b54a801bd", "{ \"columns\": [ \"Pekin Boz\", \"Fazilet Hacıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 174, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 10, 56, 21, 0, DateTimeKind.Unspecified) },
                    { "961a22ec-73b3-4370-b830-3f5b921859ab", "{ \"columns\": [ \"Aksu Bozdağ\", \"Kıvılcım Hadi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 175, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 12, 4, 49, 0, DateTimeKind.Unspecified) },
                    { "288522e8-f6b3-4940-9269-430ece3624e8", "{ \"columns\": [ \"Arkan Bozdemir\", \"Çisil Hazal Hafız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 176, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 19, 31, 34, 0, DateTimeKind.Unspecified) },
                    { "255a31c6-49b7-4b12-8ec3-8d570801f258", "{ \"columns\": [ \"İltem Boztepe\", \"Feray Hakverdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 177, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 1, 38, 54, 0, DateTimeKind.Unspecified) },
                    { "11b89e23-caf0-4d4d-b721-c162edc493b2", "{ \"columns\": [ \"Betül Bozyer\", \"Büşranur Halaçoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 178, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 8, 0, 21, 0, DateTimeKind.Unspecified) },
                    { "8c0ee74c-9b57-4be8-9ecb-a59bd669b992", "{ \"columns\": [ \"Ogün Bölge\", \"Selin Sıla Halıcılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 179, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 18, 21, 57, 0, DateTimeKind.Unspecified) },
                    { "2210138c-04ba-4743-9f49-9bfad83fce91", "{ \"columns\": [ \"İbrahim Hakkı Bugey\", \"Yeter Hamamcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 3, 42, 1, 0, DateTimeKind.Unspecified) },
                    { "89b34186-ac20-47f0-8df3-eb88b58fb01a", "{ \"columns\": [ \"Onay Buğdaypınarı\", \"Ramazan Tarık Hamarat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 181, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 13, 37, 52, 0, DateTimeKind.Unspecified) },
                    { "176e4845-b5e4-48ee-b358-d7320907b3b4", "{ \"columns\": [ \"Cankız Bulgan\", \"Boran Hamidi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 182, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 4, 19, 58, 0, DateTimeKind.Unspecified) },
                    { "134da1be-c7f0-46e2-a18f-53e5a12b13d3", "{ \"columns\": [ \"Arzucan Bulgur\", \"Tazika Hilal Hamzaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 183, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 22, 40, 51, 0, DateTimeKind.Unspecified) },
                    { "12d54987-2396-4124-aedf-3cb152de5ce1", "{ \"columns\": [ \"Asiye Burabak\", \"Aynur Dilan Hancı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 184, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 2, 8, 47, 0, DateTimeKind.Unspecified) },
                    { "76dbb096-4b2d-424a-999e-b796c0371b00", "{ \"columns\": [ \"Buse Gizem Berker\", \"Eylem Gündüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 157, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 18, 10, 0, DateTimeKind.Unspecified) },
                    { "1e27604b-ea5a-4c15-851f-e1578d105863", "{ \"columns\": [ \"Ahmet Yasin Burak\", \"Ayman Hangül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 185, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 21, 2, 50, 44, 0, DateTimeKind.Unspecified) },
                    { "f8c4fd66-95af-4984-9df0-5e2014ca30b6", "{ \"columns\": [ \"Hüner Berk\", \"Öymen Gümüşsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 156, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 21, 14, 45, 0, DateTimeKind.Unspecified) },
                    { "f0dc398f-462e-4db5-a9e7-24dcb308b58d", "{ \"columns\": [ \"Hulki Bent\", \"Köksal Gültaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 154, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 35, 26, 0, DateTimeKind.Unspecified) },
                    { "b459c05f-c5a9-48e8-b5ed-8f0a2b82724d", "{ \"columns\": [ \"Serdar Kaan Barbaros\", \"Kubra Göçmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 127, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 17, 10, 6, 0, DateTimeKind.Unspecified) },
                    { "874eef5f-3914-455f-a650-68aa37982674", "{ \"columns\": [ \"Ezel Bargan\", \"Kubilay Gödek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 128, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 49, 28, 0, DateTimeKind.Unspecified) },
                    { "927aaf8d-0897-459e-a103-65c0aac765d0", "{ \"columns\": [ \"Ayşegül Barutçuoğlu\", \"Busem Gökçeaslan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 129, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 1, 58, 28, 0, DateTimeKind.Unspecified) },
                    { "64484ee9-f53c-4ade-a9ba-d104232cc613", "{ \"columns\": [ \"Sefa Kadir Başar\", \"Banuhan Gökçek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 130, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 6, 15, 21, 0, DateTimeKind.Unspecified) },
                    { "1b6f03ec-c732-4311-84cf-fea70316b218", "{ \"columns\": [ \"Elif Etga Başeğmez\", \"Örgün Gökhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 131, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 2, 3, 20, 0, DateTimeKind.Unspecified) },
                    { "5503a0ee-dde5-4aec-ac55-1ed16bbc8e9a", "{ \"columns\": [ \"Balın Baştepe\", \"Melike Göksoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 132, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 42, 8, 0, DateTimeKind.Unspecified) },
                    { "eecf68a2-fe1d-4072-b9d1-d717a62f430e", "{ \"columns\": [ \"Mahperi Baştopçu\", \"Yeşim Gölmes\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 133, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 26, 28, 0, DateTimeKind.Unspecified) },
                    { "deb2bd0d-73f1-463b-8963-89a70e3b0484", "{ \"columns\": [ \"Erol Özgür Baştuğ\", \"Nilüfer Gönay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 134, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 22, 39, 49, 0, DateTimeKind.Unspecified) },
                    { "6d1d5bcd-3f5b-47a0-a71c-f4086d4a20d9", "{ \"columns\": [ \"Atak Batar\", \"Denizhan Gönül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 135, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 10, 10, 33, 0, DateTimeKind.Unspecified) },
                    { "d5e98ca8-db30-46a0-9459-31e1da929265", "{ \"columns\": [ \"Safa Batga\", \"Şueda Göreke\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 136, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 21, 5, 6, 53, 0, DateTimeKind.Unspecified) },
                    { "89ff8b37-9459-4b8a-a429-8afd3d4880b4", "{ \"columns\": [ \"Gökmen Battal\", \"Ersin Görgülü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 137, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 18, 7, 24, 0, DateTimeKind.Unspecified) },
                    { "4d0cc310-69b5-490e-aca4-1d0c87448f9b", "{ \"columns\": [ \"Fazıl Erem Batuk\", \"Şahabettin Görgüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 138, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 22, 50, 59, 0, DateTimeKind.Unspecified) },
                    { "5b8441d5-671f-4a27-940e-f986500bb4e4", "{ \"columns\": [ \"Bensu Batur\", \"Ayşe Elif Görür\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 139, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 15, 40, 0, DateTimeKind.Unspecified) },
                    { "138f7a74-2579-458f-a920-18a2eece6a57", "{ \"columns\": [ \"Nazım Orhun Baturalp\", \"Nazım Berke Göven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 140, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 2, 59, 2, 0, DateTimeKind.Unspecified) },
                    { "c094f8e1-d1a6-4e7d-ae79-61a0bd473cf6", "{ \"columns\": [ \"Safa Ahmet Baydar\", \"Meltem Göymen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 141, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 37, 28, 0, DateTimeKind.Unspecified) },
                    { "0ae1a4c6-e03a-40e1-abdf-8f2154051fc8", "{ \"columns\": [ \"Demircan Baydil\", \"Abdulhalim Guguk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 142, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 16, 0, 53, 0, DateTimeKind.Unspecified) },
                    { "ee3ede1f-ba94-4c7b-9e26-428e149e2211", "{ \"columns\": [ \"Burçin Kübra Baykal\", \"Gülten Güdücü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 143, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 12, 19, 44, 0, DateTimeKind.Unspecified) },
                    { "f31dc29a-6033-4470-9562-20ca2b8174a0", "{ \"columns\": [ \"Derviş Haluk Baykan\", \"Işınbıke Gülcan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 144, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 19, 0, 58, 0, DateTimeKind.Unspecified) },
                    { "987ef194-4338-478e-a030-3f11a877ade9", "{ \"columns\": [ \"Taylan Remzi Baykuş\", \"Vedia Gülçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 145, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 11, 3, 45, 0, DateTimeKind.Unspecified) },
                    { "0f2c5ddb-6c1d-4610-a4a6-f3cd1c7361f3", "{ \"columns\": [ \"Abdulvahap Bayrakoğlu\", \"Fatma Sena Güldoğuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 146, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 8, 34, 23, 0, DateTimeKind.Unspecified) },
                    { "f78b0a07-f611-4b09-af04-9882a71dccf0", "{ \"columns\": [ \"Aygün Bayram\", \"Ömer Okan Gülebakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 147, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 13, 16, 12, 0, DateTimeKind.Unspecified) },
                    { "0f7ba50f-aa26-4edf-b1c6-84ecd5df1cd9", "{ \"columns\": [ \"Ayla Baytın\", \"Aybike Güleç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 148, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 28, 27, 0, DateTimeKind.Unspecified) },
                    { "9cc74ec1-d209-44ad-b0eb-5cf3c94cd794", "{ \"columns\": [ \"Kubilay Barış Begiç\", \"Bektaş Gülenç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 149, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 6, 49, 0, DateTimeKind.Unspecified) },
                    { "049953d3-4d6c-41b7-8b56-be849a40ec99", "{ \"columns\": [ \"Mustafa Samed Beğenilmiş\", \"Emircan Güleryüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 20, 37, 0, DateTimeKind.Unspecified) },
                    { "226c7330-c370-4877-bec1-2dea926ff878", "{ \"columns\": [ \"Berfin Dilay Bekaroğlu\", \"Merter Gülkan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 151, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 14, 53, 12, 0, DateTimeKind.Unspecified) },
                    { "fdf24699-0470-4581-8cf4-75fce6602f31", "{ \"columns\": [ \"İbrahim Onat Belge\", \"Sevgi Tutku Güllüce\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 152, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 10, 45, 7, 0, DateTimeKind.Unspecified) },
                    { "beb18ab5-3f05-443b-b9bc-cf50b29a2a63", "{ \"columns\": [ \"Jutenya Benan\", \"Denktaş Gülşen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 153, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 21, 14, 22, 0, DateTimeKind.Unspecified) },
                    { "cbcee28e-8017-4a16-8ac7-65943ff599d0", "{ \"columns\": [ \"Mustafa Doğukan Berberoğlu\", \"Hasan Fahri Gültepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 155, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 14, 44, 16, 0, DateTimeKind.Unspecified) },
                    { "651663d1-c9ab-4eab-83ce-dbd94bdc8dc1", "{ \"columns\": [ \"Yaprak Bural\", \"Berrak Harman\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 186, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 22, 10, 53, 0, DateTimeKind.Unspecified) },
                    { "b7c6e629-f629-49b7-873e-ebff3b442d94", "{ \"columns\": [ \"Aleda Buyuran\", \"Erk Deha Harmankaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 187, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 0, 41, 0, DateTimeKind.Unspecified) },
                    { "99c2e9bd-dd2f-4b19-aeac-194c23a2856b", "{ \"columns\": [ \"Can Güney Bülbül\", \"Perihan Haykır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 188, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 11, 4, 40, 0, DateTimeKind.Unspecified) },
                    { "434052a8-94c3-4161-89db-c1fafa878abe", "{ \"columns\": [ \"Mahire Çalım\", \"Bergüzar Kaçaranoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 221, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 10, 18, 45, 0, DateTimeKind.Unspecified) },
                    { "3621bf15-7546-4af3-9230-8d586d5b1de2", "{ \"columns\": [ \"Hacı Bayram Ufuk Çamaş\", \"Ömer Faruk Kadı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 222, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 12, 13, 48, 0, DateTimeKind.Unspecified) },
                    { "227277e4-f682-499a-842c-36b68d1bdd94", "{ \"columns\": [ \"Oltun Çanga\", \"Dağhan Kadoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 223, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 19, 24, 58, 0, DateTimeKind.Unspecified) },
                    { "3bd5abd0-4a4f-4e1b-b0ac-cbc68c66fff0", "{ \"columns\": [ \"Önel Çapa\", \"Ünzile Kalfaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 224, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 8, 36, 10, 0, DateTimeKind.Unspecified) },
                    { "67bea26e-7813-4833-a025-2156d49b523c", "{ \"columns\": [ \"Bayülken Çaprak\", \"Sezer Kalsın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 225, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 3, 12, 24, 0, DateTimeKind.Unspecified) },
                    { "be39c4d0-1c94-41a3-9c22-609bed2658e3", "{ \"columns\": [ \"Dilseren Çarıcı\", \"Şensoy Kalyoncu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 226, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 14, 32, 23, 0, DateTimeKind.Unspecified) },
                    { "76980e89-12b6-408d-ad50-920e030cc87c", "{ \"columns\": [ \"Elif Beyza Çark\", \"Necatı Kamışlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 227, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 11, 44, 37, 0, DateTimeKind.Unspecified) },
                    { "5db5b60e-2d41-478a-a9dd-7b678467d152", "{ \"columns\": [ \"Elvan Çatal\", \"Şahan Kandaşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 228, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "aa028874-dbab-4103-b466-2505f375643c", "{ \"columns\": [ \"Esim Çaylar\", \"Necip Fazıl Kanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 229, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 11, 38, 41, 0, DateTimeKind.Unspecified) },
                    { "a1362277-3436-4e99-acdf-82596f359d68", "{ \"columns\": [ \"Sena Çekmecelioğlu\", \"Muharrem Kanmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 230, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 21, 2, 33, 17, 0, DateTimeKind.Unspecified) },
                    { "d14662be-2c89-4b49-bac4-58565e4ccb7f", "{ \"columns\": [ \"Muhammed Üzeyir Çekmeci\", \"Zeynep Figen Kantarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 231, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 0, 56, 0, DateTimeKind.Unspecified) },
                    { "bf4580df-5d6b-496e-8ac5-42410513236b", "{ \"columns\": [ \"Aydın Mert Çelebican\", \"Çilay Kapsız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 232, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 10, 8, 25, 0, DateTimeKind.Unspecified) },
                    { "b6891890-c449-4e63-b338-4da8975978de", "{ \"columns\": [ \"Çağkan Çelenlioğlu\", \"Suna Karaaslanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 233, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 14, 17, 11, 0, DateTimeKind.Unspecified) },
                    { "cd848b71-23f8-48f1-9f51-c9455ac11ba1", "{ \"columns\": [ \"Zümra Çelık\", \"Ahmet Can Karabacak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 234, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 18, 20, 41, 0, DateTimeKind.Unspecified) },
                    { "6d5cbd66-bd57-4524-a3c4-eb37645c2805", "{ \"columns\": [ \"Bayar Çelik\", \"Asya Sema Karabağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 235, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 3, 54, 2, 0, DateTimeKind.Unspecified) },
                    { "3d81d272-6ce7-4718-9368-94e39a9eae2e", "{ \"columns\": [ \"Gönülgül Çelikağı\", \"Gül Sena Karabıyık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 236, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 1, 17, 39, 0, DateTimeKind.Unspecified) },
                    { "aaa4af89-575b-4008-aa9e-ea6fdce8654b", "{ \"columns\": [ \"Ece Pınar Çeliker\", \"Fatma Büşra Karabıyıklı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 237, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 6, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "b00d79e7-8b4f-40a8-877d-a9dd7f251995", "{ \"columns\": [ \"Mehmet Tarık Çelikkol\", \"Arca Karabulut\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 238, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 10, 7, 29, 0, DateTimeKind.Unspecified) },
                    { "74125d20-1e00-4cb9-8c5f-6992bef0bbb0", "{ \"columns\": [ \"Elife Çerçi\", \"Abdullatif Karacabey\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 239, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 6, 6, 10, 0, DateTimeKind.Unspecified) },
                    { "b3554f17-3f56-4c10-9141-dab1f0f33c06", "{ \"columns\": [ \"Efecan Çetintaş\", \"Tuğra Karacan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 240, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 6, 32, 13, 0, DateTimeKind.Unspecified) },
                    { "0143bb4d-77a1-493f-8a2a-828ea82d24d3", "{ \"columns\": [ \"Rıdvan Çıkıkcı\", \"Emir Doğan Karaçay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 241, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 7, 58, 42, 0, DateTimeKind.Unspecified) },
                    { "e680c723-56bb-4b10-a6e7-e8938c238d15", "{ \"columns\": [ \"Hatice Gamze Çınar\", \"Haluk Barış Karaçeşme\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 242, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 3, 8, 19, 0, DateTimeKind.Unspecified) },
                    { "4e8a2466-1ed2-4268-bd59-9b36d1f067d3", "{ \"columns\": [ \"Yansı Hilal Çınaroğlu\", \"Seyit Ahmet Karadağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 243, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 57, 51, 0, DateTimeKind.Unspecified) },
                    { "06bade87-f863-4d38-aecd-75dd6f1cd07b", "{ \"columns\": [ \"Omaç Çıngır\", \"Cevza Karadalan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 244, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 4, 22, 52, 0, DateTimeKind.Unspecified) },
                    { "49f49823-7ff6-443e-87f9-395d309dbcc9", "{ \"columns\": [ \"Erhan Çıray\", \"Mustafa Emir Karademir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 245, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 23, 13, 26, 0, DateTimeKind.Unspecified) },
                    { "c3ad1412-5a28-4a16-b0c0-16cc860e9bf7", "{ \"columns\": [ \"Şüheda Çiçekli\", \"Ilgar Pamir Karaismail\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 246, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 1, 10, 50, 0, DateTimeKind.Unspecified) },
                    { "12da3fbc-6f65-4761-8916-b66bef6406c5", "{ \"columns\": [ \"Ünkan Çini\", \"Seren Karakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 247, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 17, 32, 0, DateTimeKind.Unspecified) },
                    { "30eb11e2-6cd5-4ee2-860e-d4138970e447", "{ \"columns\": [ \"Maral Çakıcı\", \"Şaziye Kabukçu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 220, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 20, 21, 1, 0, DateTimeKind.Unspecified) },
                    { "18739f57-0142-4f98-9838-5e9e6eabbcc6", "{ \"columns\": [ \"Dilhan Çakanel\", \"Melis Ezgi Kabayuka\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 219, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 11, 58, 0, DateTimeKind.Unspecified) },
                    { "87628ea5-f70b-4dff-a469-eca2a2e0ec72", "{ \"columns\": [ \"Özen Çakan\", \"Uzel Kabataş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 218, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 11, 53, 6, 0, DateTimeKind.Unspecified) },
                    { "30b0ef94-21eb-45e0-8b55-14f649c9663c", "{ \"columns\": [ \"Elif Ege Çağlayan\", \"Ahuşen İşgüzar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 217, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 23, 43, 16, 0, DateTimeKind.Unspecified) },
                    { "ac8ac469-cab6-4436-b267-105e293a8c79", "{ \"columns\": [ \"Mahmut Bilal Bülend\", \"Turhan Onur Hırlak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 189, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 8, 28, 45, 0, DateTimeKind.Unspecified) },
                    { "4ba2d6e2-b4c9-4973-8143-5bab539ec503", "{ \"columns\": [ \"Saliha Zeynep Bülent\", \"Furkan Hızarcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 190, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 7, 58, 41, 0, DateTimeKind.Unspecified) },
                    { "6956a01a-f30c-4232-90f5-1f9ebc165bc9", "{ \"columns\": [ \"Melike Dilara Büyükfırat\", \"Mustafa Ali Hiçyılmam\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 191, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 20, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { "5eedc6bc-079d-4676-b7cf-1ddfa933399a", "{ \"columns\": [ \"Hayriye Büyükgüngör\", \"Muhammed Sefa Hilal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 192, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 12, 45, 42, 0, DateTimeKind.Unspecified) },
                    { "23a04691-96c4-41f0-9614-764d5629ed0f", "{ \"columns\": [ \"Sebiha Büyüköztürk\", \"Argün Hilmi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 193, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 10, 25, 56, 0, DateTimeKind.Unspecified) },
                    { "0c651bd6-eead-47e3-b420-3b3fc35550d1", "{ \"columns\": [ \"Mehmet Can Akçaözoğlu\", \"Fadik Himoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 194, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 21, 3, 57, 41, 0, DateTimeKind.Unspecified) },
                    { "c7d83ecb-35d4-46e5-9ddd-0c5896595f72", "{ \"columns\": [ \"Mehmet Enes Canan\", \"Ahmet Hakkı Hirik\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 195, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 9, 8, 41, 0, DateTimeKind.Unspecified) },
                    { "90ecdeb4-0786-4e4f-bcf4-e2fe604d7d45", "{ \"columns\": [ \"Kurtbey Canbağı\", \"Mustafa Sefa Hopacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 196, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 10, 35, 32, 0, DateTimeKind.Unspecified) },
                    { "94f69c1f-be03-4c7a-ba37-7d2042d30a08", "{ \"columns\": [ \"Mustafa Taha Canbek\", \"Toykan Horata\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 197, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 14, 38, 48, 0, DateTimeKind.Unspecified) },
                    { "a3243a52-bf68-4e0e-83d5-bd67b095d7f6", "{ \"columns\": [ \"Sena Nur Candan\", \"Selime Hüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 198, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 4, 51, 29, 0, DateTimeKind.Unspecified) },
                    { "484f696e-beef-4516-ac2e-3b7fc39916a8", "{ \"columns\": [ \"Abdullah Emirhan Caner\", \"Denizcan Ilık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 199, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 23, 44, 6, 0, DateTimeKind.Unspecified) },
                    { "07bd0460-edba-4c60-aa28-87585309af83", "{ \"columns\": [ \"Mustafa Kerem Cansu\", \"Ayşe Zeyneb Irıcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 34, 2, 0, DateTimeKind.Unspecified) },
                    { "b8e4cbf1-8ea3-48b4-b698-83009c8ed206", "{ \"columns\": [ \"Doktora Canuyar\", \"Mustafa Furkan Işınay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 201, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 11, 16, 38, 0, DateTimeKind.Unspecified) },
                    { "95981a58-f2fd-4133-955b-c3c587d2c2ec", "{ \"columns\": [ \"Coşkun Baran\", \"Tilbe Göç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 126, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 21, 11, 38, 0, DateTimeKind.Unspecified) },
                    { "4a2152f5-ddba-44c3-acc0-e8cb6a22dae0", "{ \"columns\": [ \"Seyit Ceran\", \"Sude İbrahim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 202, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 17, 47, 59, 0, DateTimeKind.Unspecified) },
                    { "03748a06-e75b-45e2-8aa9-a56b9aa85478", "{ \"columns\": [ \"Aşkım Chiklyaukova\", \"Katya İlgezdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 204, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 4, 49, 51, 0, DateTimeKind.Unspecified) },
                    { "5e59a338-0e1f-4d65-94bc-6c7e90aa7867", "{ \"columns\": [ \"Özgür Choi\", \"Halid İlhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 205, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 16, 3, 4, 0, DateTimeKind.Unspecified) },
                    { "2dce6a05-d95a-47a9-b7a8-c31f1182bf89", "{ \"columns\": [ \"Tuğce Cibooğlu\", \"Nihal İlısu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 206, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 57, 28, 0, DateTimeKind.Unspecified) },
                    { "dddedf11-2dd4-4974-8bc3-a0d72d59ea57", "{ \"columns\": [ \"Özer Seçkin Ciddi\", \"Elif Nisan İmamoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 207, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 16, 36, 14, 0, DateTimeKind.Unspecified) },
                    { "0b495873-f2dd-4677-9da4-128b0b523faa", "{ \"columns\": [ \"Balkın Cigerlioğlu\", \"Emine Selcen İmre\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 208, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 20, 26, 52, 0, DateTimeKind.Unspecified) },
                    { "4783fb79-d7e5-4b78-8109-875776cbb070", "{ \"columns\": [ \"Yücel Civan\", \"Tevfik İnal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 209, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 4, 2, 0, DateTimeKind.Unspecified) },
                    { "bbb0db9b-1ca4-4428-8fa3-fa2bff482949", "{ \"columns\": [ \"Şansal Coşan\", \"İbrahim Kağan İncekara\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 210, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 19, 51, 38, 0, DateTimeKind.Unspecified) },
                    { "af44fe74-b993-4356-b2de-a4a34096715f", "{ \"columns\": [ \"Oğuzcan Coşandal\", \"Sidar İnceoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 211, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 6, 14, 55, 0, DateTimeKind.Unspecified) },
                    { "7100ceae-8816-4ff7-bf09-7e43488e496c", "{ \"columns\": [ \"Mayıs Cumalı\", \"Nesli İpçizade\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 212, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 16, 19, 36, 0, DateTimeKind.Unspecified) },
                    { "23749af8-36eb-462d-9750-93a8539dc1f5", "{ \"columns\": [ \"Büşra Cüce\", \"İhsan Vehbi İpekoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 213, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 8, 28, 52, 0, DateTimeKind.Unspecified) },
                    { "61722061-f21f-467d-a513-f822e1990a2f", "{ \"columns\": [ \"Afra Selcen Çağan\", \"Necati İrsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 214, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 7, 59, 0, DateTimeKind.Unspecified) },
                    { "2b6525e5-36fc-4ffc-9c00-247b6e98a462", "{ \"columns\": [ \"Gönül Çağatay\", \"Zerin İshakoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 215, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 4, 59, 44, 0, DateTimeKind.Unspecified) },
                    { "458b67a7-d784-41c3-b478-f186d3cdc34c", "{ \"columns\": [ \"Doğangün Çağlar\", \"Dursun Korel İşgören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 216, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 14, 6, 11, 0, DateTimeKind.Unspecified) },
                    { "123b59aa-42c0-4364-9dba-9fa8fb94da59", "{ \"columns\": [ \"Selma Simge Ceylan\", \"Güçlü İçten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 203, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 9, 30, 8, 0, DateTimeKind.Unspecified) },
                    { "f0b5b1af-fe23-45e6-933e-ad7ef5915667", "{ \"columns\": [ \"Ahmet Gazi Çintan\", \"Büşra Hazal Karakaplan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 248, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 29, 21, 0, DateTimeKind.Unspecified) },
                    { "2efa8fd6-fd87-44d9-a60f-ac8ab2059559", "{ \"columns\": [ \"Abdullah Atakan Baluken\", \"Abdullah Halit Golba\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 125, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 2, 58, 0, DateTimeKind.Unspecified) },
                    { "7fd2a5bd-7381-4292-828c-e4bc92cd4540", "{ \"columns\": [ \"Sakıp Balıoğlu\", \"Mehmet Gökalp Ginoviç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 123, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 9, 42, 35, 0, DateTimeKind.Unspecified) },
                    { "f5fce459-7af4-40fd-aa93-7ac7c655c24f", "{ \"columns\": [ \"Nüket Aksan\", \"Bedir Destereci\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 33, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 7, 55, 50, 0, DateTimeKind.Unspecified) },
                    { "2a90cdca-3dba-432c-9fc7-2c26a0912230", "{ \"columns\": [ \"Senem Aksevim\", \"Rümeysa İrem Devecel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 6, 21, 36, 0, DateTimeKind.Unspecified) },
                    { "8ac62062-536a-49d8-9264-915814355730", "{ \"columns\": [ \"Ayşen Aksoy\", \"Osman Sinan Devrim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 18, 25, 29, 0, DateTimeKind.Unspecified) },
                    { "765957a5-d0e6-4a7c-875b-44aff89939d0", "{ \"columns\": [ \"Pekcan Aksöz\", \"Saliha Canan Dıvarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 20, 16, 22, 43, 0, DateTimeKind.Unspecified) },
                    { "762bf5ff-4fe3-4cb7-ae44-0e4361d6db97", "{ \"columns\": [ \"Bedirhan Lütfü Akşamoğlu\", \"Samet Emre Dikbaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 20, 9, 4, 0, DateTimeKind.Unspecified) },
                    { "8cb83dd7-d811-483d-8cc6-4d58f3a888c8", "{ \"columns\": [ \"Semina Aktuna\", \"Haldun Dinçtürk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 5, 6, 0, DateTimeKind.Unspecified) },
                    { "b50c824e-8e70-4b69-9727-0e8470e71f16", "{ \"columns\": [ \"Eda Sena Akyıldız\", \"Goncagül Diri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 10, 11, 27, 0, DateTimeKind.Unspecified) },
                    { "c260c974-dfbb-41ae-ab3c-9162a5e6ff31", "{ \"columns\": [ \"Müyesser Akyildirim\", \"Ziya Doğramacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 26, 45, 0, DateTimeKind.Unspecified) },
                    { "96c8274e-0ecd-4423-bdc2-f6c3d9d860fc", "{ \"columns\": [ \"Selinti Al\", \"Zehra Pelin Döger\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 9, 3, 34, 0, DateTimeKind.Unspecified) },
                    { "35a83e82-cc22-4bb2-b5e0-919f2756e7cb", "{ \"columns\": [ \"Bahar Özlem Albaş\", \"Seli M Sharef Dökülmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 58, 37, 0, DateTimeKind.Unspecified) },
                    { "28ace80b-c109-4962-ae37-523235215810", "{ \"columns\": [ \"İlma Aldağ\", \"Firuze Dönder\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 43, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 48, 44, 0, DateTimeKind.Unspecified) },
                    { "d2c5eb5b-77b9-439b-ab3e-2d27404bb6dc", "{ \"columns\": [ \"Kutlu Alibeyoğlu\", \"Doruk Deniz Döner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 15, 40, 2, 0, DateTimeKind.Unspecified) },
                    { "02fcbbcc-3245-475d-8881-45a30f4e12fc", "{ \"columns\": [ \"Nesibe Nurefşan Alkan\", \"Çisil Zeynep Dönmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 22, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "17904827-6e3a-486f-8184-829ed87f852d", "{ \"columns\": [ \"Ömer Buğra Alparslan\", \"Tugce Dudu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 46, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 16, 14, 54, 0, DateTimeKind.Unspecified) },
                    { "dd8fe6b9-fb96-46bf-9c2d-fe0281576374", "{ \"columns\": [ \"Hiba Alpuğan\", \"Enver Dur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 47, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 41, 42, 0, DateTimeKind.Unspecified) },
                    { "2b585572-ad9a-40ca-bf0a-bc26ba8421be", "{ \"columns\": [ \"Mazlum Altan\", \"Sanber Durak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 48, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 22, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "ee87d008-0bb8-4bf1-a4f2-628323c0c6e5", "{ \"columns\": [ \"Elif Tuğçe Altaş\", \"Birsen Durmuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 49, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 13, 24, 34, 0, DateTimeKind.Unspecified) },
                    { "a00c7fcc-37c3-466d-8d74-4f75377fb407", "{ \"columns\": [ \"Ahmet Ruken Altay\", \"Taçmin Durmuşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 1, 18, 6, 0, DateTimeKind.Unspecified) },
                    { "f7ed4c71-f236-458d-a61e-37ff521c639b", "{ \"columns\": [ \"Yaşar Utku Anıl Altın\", \"Karanalp Dursun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 51, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 18, 49, 0, DateTimeKind.Unspecified) },
                    { "6e987ed9-680c-43b7-b032-3b8ee1552490", "{ \"columns\": [ \"Rana Altınoklu\", \"Öktem Duymuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 52, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 8, 31, 0, DateTimeKind.Unspecified) },
                    { "181ba59a-7278-4da0-b5c5-eb9bd25d5456", "{ \"columns\": [ \"Fethullah Altınöz\", \"Elanaz Dülgerbaki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 53, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 19, 28, 29, 0, DateTimeKind.Unspecified) },
                    { "813664bf-5b5b-489e-a469-906e6ff6a1a2", "{ \"columns\": [ \"Burak Tatkan Altıntaş\", \"Fidan Dündar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 54, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 7, 32, 0, DateTimeKind.Unspecified) },
                    { "bd906b06-8321-4887-8c47-80b60ad4c94e", "{ \"columns\": [ \"Merve Ece Altıok\", \"Barın Düşenkalkar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 55, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 20, 58, 35, 0, DateTimeKind.Unspecified) },
                    { "826db4cf-876c-4df1-90e5-c1aed25c896c", "{ \"columns\": [ \"Rima Altıparmak\", \"Mehmet Erman Düzbayır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 56, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 20, 7, 20, 0, DateTimeKind.Unspecified) },
                    { "bce111ef-8611-40fb-a4c3-e9bdfbf53c28", "{ \"columns\": [ \"Elif Dilay Altinkaya\", \"Cem Efe Edeş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 57, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 11, 6, 33, 0, DateTimeKind.Unspecified) },
                    { "8b0cb13c-e6d3-4f42-9685-298de48e479b", "{ \"columns\": [ \"Sırma Begüm Altunbaş\", \"Erem Edibali Mp\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 58, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 10, 50, 5, 0, DateTimeKind.Unspecified) },
                    { "aec5cc2c-9e15-416c-a6e0-787abe900fe8", "{ \"columns\": [ \"Nefse Altunbulak\", \"Volkan Eyüp Efşin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 59, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 19, 53, 36, 0, DateTimeKind.Unspecified) },
                    { "52a72e1a-6468-4ef0-8c9a-9d0b9cbac83f", "{ \"columns\": [ \"Ecem Hatice Akova\", \"Dalay Derya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 32, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 21, 54, 30, 0, DateTimeKind.Unspecified) },
                    { "032b36c0-ff4f-4ec6-b53a-e46740c87888", "{ \"columns\": [ \"Büşra Gül Altundal\", \"İbrahim Alp Tekin Ege\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 15, 13, 58, 0, DateTimeKind.Unspecified) },
                    { "12558902-4ece-47f4-af00-b7ac6935b833", "{ \"columns\": [ \"Ahmet Raşit Akoğuz\", \"Tubanur Dereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 14, 11, 0, DateTimeKind.Unspecified) },
                    { "d1e3dd39-56ec-4d90-999a-ee5bedfb713f", "{ \"columns\": [ \"Ahmet Polat Aklar Çörekçi\", \"Alya Denizgünü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 3, 37, 0, DateTimeKind.Unspecified) },
                    { "7fec90f4-7014-4efb-a2b1-5b89b213365d", "{ \"columns\": [ \"Atahan Adanır\", \"Ozan Ege Çomu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 16, 35, 59, 0, DateTimeKind.Unspecified) },
                    { "af1ade0a-cada-43b2-99be-256aaa8671e2", "{ \"columns\": [ \"Hacı Mehmet Adıgüzel\", \"Hilal Ebru Çonay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 10, 8, 37, 0, DateTimeKind.Unspecified) },
                    { "a2eaceee-2caa-465b-a2be-fed69a7a3ae1", "{ \"columns\": [ \"Mükerrem Zeynep Ağca\", \"Ayben Çorumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 20, 19, 52, 0, 0, DateTimeKind.Unspecified) },
                    { "5f56525f-58a8-497e-8789-d944b3021135", "{ \"columns\": [ \"Bestami Ağırağaç\", \"Abdulbaki Çotur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 0, 30, 39, 0, DateTimeKind.Unspecified) },
                    { "61b96090-1ad4-4349-9769-67b8141fbc19", "{ \"columns\": [ \"Aykanat Ağıroğlu\", \"Neva Çuhadar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 6, 58, 40, 0, DateTimeKind.Unspecified) },
                    { "eceb15f1-7871-43e7-9ef7-59db1bc38511", "{ \"columns\": [ \"Şennur Ağnar\", \"Öznur Çulhaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 15, 19, 12, 0, DateTimeKind.Unspecified) },
                    { "9d262b19-21e7-462b-aecc-781bcc32eeac", "{ \"columns\": [ \"Tutkum Ahmadı Asl\", \"Olgun Dadalıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "55b38b94-6fdf-42a7-aed7-3f4ba0b5042c", "{ \"columns\": [ \"Mügenur Ahmet\", \"Çağrı Atahan Dağar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 9, 12, 7, 0, DateTimeKind.Unspecified) },
                    { "0c449ec8-3551-4528-a7a3-ef880a026c84", "{ \"columns\": [ \"Sevinç Ak\", \"Özalp Dağbağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 10, 36, 1, 0, DateTimeKind.Unspecified) },
                    { "18c65154-93d7-48de-91ff-95d42ed738c0", "{ \"columns\": [ \"Kayıhan Nedim Akarcalı\", \"Hüsne Aysun Dal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 7, 40, 22, 0, DateTimeKind.Unspecified) },
                    { "00eba878-bada-4085-b0b6-abec13325136", "{ \"columns\": [ \"Fatma Özlem Acar\", \"Gürbüz Çivici\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 8, 37, 49, 0, DateTimeKind.Unspecified) },
                    { "2c2fe317-c11c-44dd-a225-f844bd4e1f09", "{ \"columns\": [ \"Lemi Akarçay\", \"Aydonat Dalkılıç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 18, 53, 26, 0, DateTimeKind.Unspecified) },
                    { "dbbd77fe-833a-45bf-bb1f-b611ebe22178", "{ \"columns\": [ \"Cihan Akarpınar\", \"Ezgin Dallı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 23, 23, 27, 0, DateTimeKind.Unspecified) },
                    { "c1a0dc00-1500-4c58-a29a-af27a11cf82d", "{ \"columns\": [ \"Rafi Akaş\", \"Refiye Seda Dalyaprak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 0, 20, 26, 0, DateTimeKind.Unspecified) },
                    { "5e87c03a-3c5f-4d23-9677-5ebe88e79f43", "{ \"columns\": [ \"Mehmetcan Akay\", \"Esat Erdem Daniş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 59, 39, 0, DateTimeKind.Unspecified) },
                    { "5d285246-3f87-4d3e-b497-f616cd2df749", "{ \"columns\": [ \"Nuhaydar Akbilmez\", \"Ayşe Neslihan Daşdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 6, 32, 0, DateTimeKind.Unspecified) },
                    { "46efd462-741d-4796-85ff-a0bedf8e5895", "{ \"columns\": [ \"Emine Münevver Akca\", \"Fetullah Davutoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 52, 5, 0, DateTimeKind.Unspecified) },
                    { "d299b3be-95c3-4a7e-a233-5c0994f8e86b", "{ \"columns\": [ \"Servet Akçagunay\", \"Mert Görkem Dayıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 6, 22, 0, DateTimeKind.Unspecified) },
                    { "81e716e8-bee1-40f0-b496-e303c31a7e91", "{ \"columns\": [ \"Çilem Akçay\", \"Ergün Değirmendereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "b883a190-911a-4e14-8c6f-34e88995eb12", "{ \"columns\": [ \"Recep Ali Samet Akdoğan\", \"Hülya Delı Chasan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 1, 28, 20, 0, DateTimeKind.Unspecified) },
                    { "24d22a4c-dde8-495c-bb80-370c30326c58", "{ \"columns\": [ \"Emre Ayberk Akfırat\", \"Doga Elif Delice\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 23, 12, 45, 0, DateTimeKind.Unspecified) },
                    { "00a5751a-9109-4524-a0ec-2e3fd14339d1", "{ \"columns\": [ \"Kerime Hacer Akıllı\", \"Muhammed Bazit Deliloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 7, 7, 46, 0, DateTimeKind.Unspecified) },
                    { "2bf6f983-84b3-4329-8cfb-45cac7fc80a0", "{ \"columns\": [ \"Ercüment Akıncılar\", \"Miraç Demırören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 21, 16, 0, DateTimeKind.Unspecified) },
                    { "f8b22f54-84c3-491c-a48b-040459e231ef", "{ \"columns\": [ \"Sarper Akış\", \"Hürel Demiriz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 4, 13, 6, 0, DateTimeKind.Unspecified) },
                    { "489e9d57-7a7f-4c41-8807-539c82168095", "{ \"columns\": [ \"Berker Akkiray\", \"Sömer Demiroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 20, 15, 59, 13, 0, DateTimeKind.Unspecified) },
                    { "deedcb9a-bbbd-47fd-a4c1-3cc07aa150dc", "{ \"columns\": [ \"İclal Akkoyun\", \"Aysel Aysu Demirsatan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 1, 58, 53, 0, DateTimeKind.Unspecified) },
                    { "af65330b-3e94-45de-b1ee-7d73278366f9", "{ \"columns\": [ \"Lemis Akküt\", \"Mehmet Kemal Dengizek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 20, 51, 9, 0, DateTimeKind.Unspecified) },
                    { "b878bf50-f871-4e76-8ab8-d29a94583335", "{ \"columns\": [ \"Ata Kerem Akman\", \"Zeynep Büşra Derdemez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 0, 27, 12, 0, DateTimeKind.Unspecified) },
                    { "969ecbf4-013c-4c05-b0b0-3bfd6282259b", "{ \"columns\": [ \"Erna Aluç\", \"Güngör Erkin Egeli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 61, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 15, 53, 4, 0, DateTimeKind.Unspecified) },
                    { "6b888bff-6026-4b36-89d4-6a412ab242e8", "{ \"columns\": [ \"Hikmet Nazlı Alver\", \"Çağın Egin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 62, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "276befc6-e54a-406e-8af7-a2875195345d", "{ \"columns\": [ \"İsmail Umut Anık\", \"Alphan Ekercan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 63, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 1, 18, 30, 0, DateTimeKind.Unspecified) },
                    { "92c2c1a6-76ce-4422-aa8b-198a3b9fbd02", "{ \"columns\": [ \"Murat Kaan Ayanoglu\", \"Belin Esendemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 96, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 22, 22, 54, 0, DateTimeKind.Unspecified) },
                    { "164fc445-bec0-466e-aaf7-4698575b5745", "{ \"columns\": [ \"Murat Sinan Ayaz\", \"Rukiye Esgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 97, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 23, 4, 53, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "6e46f926-90a3-42ba-951b-ec96e1e26b7e", "{ \"columns\": [ \"Ateş Aycı\", \"İslam Eshaqzada\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 98, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 14, 29, 28, 0, DateTimeKind.Unspecified) },
                    { "44284e62-e797-429e-9ad6-8c2861b54eae", "{ \"columns\": [ \"Zeynep Nihan Aydınlıoğlu\", \"Batıray Eski\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 99, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 23, 50, 9, 0, DateTimeKind.Unspecified) },
                    { "a76bd9ac-fe3e-4a8e-9d4d-aa5717d4c36b", "{ \"columns\": [ \"Kerime Aydoğan Yozgat\", \"Süheyl Esvap\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 19, 34, 0, DateTimeKind.Unspecified) },
                    { "73237575-14ff-4028-9cbb-b27c744e8bad", "{ \"columns\": [ \"Hami Aydoğdu\", \"Yargı Yekta Eşe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 101, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 14, 36, 11, 0, DateTimeKind.Unspecified) },
                    { "beddf605-a720-4f21-927c-0b2b97411af4", "{ \"columns\": [ \"Thomas Aygen\", \"Elzem Evrenos\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 102, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 3, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "f9ae331f-6d62-4be5-b2db-3e933d99c321", "{ \"columns\": [ \"Güneş Aykan\", \"Ilgaz Eyipişiren\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 103, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 22, 51, 0, DateTimeKind.Unspecified) },
                    { "429cab7e-0588-4d7c-a809-bba99dd2c257", "{ \"columns\": [ \"Elif Feyza Ayrım\", \"Ongar Eyyupoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 104, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 15, 3, 26, 0, DateTimeKind.Unspecified) },
                    { "6a3bbfa9-e2b6-4fce-b93f-387b847e5703", "{ \"columns\": [ \"Uğur Ali Aysal\", \"Faik Ezber\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 105, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 10, 41, 0, DateTimeKind.Unspecified) },
                    { "620fded0-cc3b-46de-974e-143d6a39a85a", "{ \"columns\": [ \"Osman Yasin Aysan\", \"Turan Fahri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 106, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 40, 27, 0, DateTimeKind.Unspecified) },
                    { "6af6aa62-2edd-4e95-95ac-05e2c60b2f1b", "{ \"columns\": [ \"Adem Ayvacık\", \"Okbay Fatih\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 107, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 33, 16, 0, DateTimeKind.Unspecified) },
                    { "eef5cb6f-bbe0-4294-8dbc-1fd8e74f936c", "{ \"columns\": [ \"Sera Cansın Azbay\", \"Latife Fatin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 108, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 16, 54, 51, 0, DateTimeKind.Unspecified) },
                    { "7b78e8ce-5a40-4c71-b414-e180d2b726a7", "{ \"columns\": [ \"Ali İsmail Babacan\", \"Eyüp Orhun Fındık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 109, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 48, 48, 0, DateTimeKind.Unspecified) },
                    { "62cc8021-b8b4-4ed4-9acb-b84be8907466", "{ \"columns\": [ \"Ruhugül Babadostu\", \"İrfan Anıl Fındıkçı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 110, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 18, 42, 0, DateTimeKind.Unspecified) },
                    { "4306114d-c416-489f-8e83-39bd15ef7c30", "{ \"columns\": [ \"Alçiçek Bad\", \"Ertuğ Furuncuoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 111, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 13, 30, 15, 0, DateTimeKind.Unspecified) },
                    { "c3aa8027-6c64-4c07-a923-3b69abd359ae", "{ \"columns\": [ \"Memet Bağcı\", \"Berhudan Garip\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 112, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 18, 14, 59, 0, DateTimeKind.Unspecified) },
                    { "c56d92bc-33e5-4610-9454-8ade5c160adc", "{ \"columns\": [ \"Mercan Bağçivan\", \"Nihan Gazitepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 113, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 11, 28, 35, 0, DateTimeKind.Unspecified) },
                    { "f2607ac2-940c-43f3-9fb2-50e9bb1e5071", "{ \"columns\": [ \"Gökay Bağış\", \"Menekşe Geben\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 114, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 21, 17, 54, 0, DateTimeKind.Unspecified) },
                    { "aca8768b-85ab-454f-aeb0-2bb576502057", "{ \"columns\": [ \"Pırıltı Bahçeli\", \"Şeniz Geboloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 115, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 13, 24, 53, 0, DateTimeKind.Unspecified) },
                    { "aed24e0e-5189-42a1-9368-f318c9a3565b", "{ \"columns\": [ \"Özgün Bahtıyar\", \"Zeynep Senahan Geçioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 116, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 13, 8, 53, 0, DateTimeKind.Unspecified) },
                    { "8ad11479-e859-4f30-af58-48467c25a514", "{ \"columns\": [ \"Özgen Baka\", \"Hayri Anıl Geçkin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 117, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 22, 39, 0, 0, DateTimeKind.Unspecified) },
                    { "08c7a708-7e94-4018-9b8e-d092717e0e28", "{ \"columns\": [ \"Seung Hun Baki\", \"Muazzez Ece Gemalmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 118, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 24, 30, 0, DateTimeKind.Unspecified) },
                    { "7e456272-4ec0-401f-8c00-a2ecc689d660", "{ \"columns\": [ \"Gülser Bal\", \"Kerem Cahit Gençoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 119, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 17, 38, 4, 0, DateTimeKind.Unspecified) },
                    { "aae55574-ebcf-4831-861d-853740e4351d", "{ \"columns\": [ \"Yüksel Balcı\", \"Sadık Can Gezmiş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 120, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 3, 41, 25, 0, DateTimeKind.Unspecified) },
                    { "145688f2-9d08-403e-b001-20da1f626639", "{ \"columns\": [ \"Ecren Baldo\", \"Resmiye Elif Gırgın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 121, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 32, 20, 0, DateTimeKind.Unspecified) },
                    { "8cb8e16f-cdf6-43dc-8b78-69d14891e182", "{ \"columns\": [ \"Muhammet Raşit Balı\", \"Nergiz Gilim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 122, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 17, 3, 38, 0, DateTimeKind.Unspecified) },
                    { "79e306d9-be57-4c78-8972-6f7d40655905", "{ \"columns\": [ \"Kaan Muharrem Ay\", \"Lütfiye Sena Esen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 95, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 16, 42, 17, 0, DateTimeKind.Unspecified) },
                    { "589b241f-bad1-42fa-9048-e09e903e9e01", "{ \"columns\": [ \"Nehar Avşar\", \"Neslihan Buşra Esat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 94, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 14, 25, 47, 0, DateTimeKind.Unspecified) },
                    { "7098dfc0-ef7e-462b-ab28-06790c868c8f", "{ \"columns\": [ \"Saime Avıandı\", \"Arslan Erzurumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 93, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 7, 31, 25, 0, DateTimeKind.Unspecified) },
                    { "bfbcecd7-21aa-4d4a-be0d-de878712f4a6", "{ \"columns\": [ \"Almina Avcı Özsoy\", \"Tunca Eryılmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 92, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 14, 28, 53, 0, DateTimeKind.Unspecified) },
                    { "644a0235-650a-49cf-a5cb-dbee4e023a75", "{ \"columns\": [ \"İlkay Ramazan Ankara\", \"Lale Ekrem\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 64, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 7, 47, 0, DateTimeKind.Unspecified) },
                    { "633678d0-0060-4d02-8efe-31833e46d1b1", "{ \"columns\": [ \"Nebahat Ansen\", \"Bağış Can Elbaşı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 12, 57, 54, 0, DateTimeKind.Unspecified) },
                    { "0c00cec4-98cc-439b-8c83-ddc06b835534", "{ \"columns\": [ \"İlyas Umut Apul\", \"Mert Cem Eliçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 66, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 13, 19, 43, 0, DateTimeKind.Unspecified) },
                    { "2d4f7da2-50f8-48a5-aea8-076fc279fc40", "{ \"columns\": [ \"Halim Aral\", \"Ahmet Sencer Emikoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 67, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 34, 17, 0, DateTimeKind.Unspecified) },
                    { "7f8fe196-3c4f-4e31-99f2-fcf79537e935", "{ \"columns\": [ \"Yasin Şükrü Arap\", \"Akife Erbay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 68, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 16, 16, 45, 0, DateTimeKind.Unspecified) },
                    { "647cdda7-f286-4c6a-b2d1-472a7eaad0d1", "{ \"columns\": [ \"Cansev Arat\", \"Burç Erbil\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 69, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 18, 50, 0, 0, DateTimeKind.Unspecified) },
                    { "edcd364a-94e5-4fa5-9007-cacc9be42db0", "{ \"columns\": [ \"Memet Ali Ardıç\", \"Nadire Erbul\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 18, 41, 29, 0, DateTimeKind.Unspecified) },
                    { "178cb058-825a-454f-8466-f83538421636", "{ \"columns\": [ \"Deniz Dilay Arıcan\", \"Hüseyin Zeyd Ercoşkun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 71, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 18, 31, 11, 0, DateTimeKind.Unspecified) },
                    { "a748b33a-53e3-420e-866a-605fdb67e65d", "{ \"columns\": [ \"İzlem Arınç\", \"Aynur Gül Ercüment\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 72, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 7, 54, 1, 0, DateTimeKind.Unspecified) },
                    { "f6550dff-a2c5-4f07-a4fb-0a6c5c97f2fe", "{ \"columns\": [ \"Öget Arif\", \"Samed Erek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 73, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 14, 42, 43, 0, DateTimeKind.Unspecified) },
                    { "5e3d68a8-29b1-4409-b28b-610200f6e497", "{ \"columns\": [ \"Şeyda Nur Arikan\", \"Cem Ozan Erim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 74, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 21, 7, 38, 18, 0, DateTimeKind.Unspecified) },
                    { "9fc6b381-c67e-46c7-ab25-183648433607", "{ \"columns\": [ \"Zeki Yiğithan Armutcu\", \"Bahar Cemre Erin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 2, 23, 47, 0, DateTimeKind.Unspecified) },
                    { "34684376-c82a-462a-8435-b37ffc127e12", "{ \"columns\": [ \"Nunazlı Arpacı\", \"Rekin Erkek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 76, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 20, 42, 49, 0, DateTimeKind.Unspecified) },
                    { "5d569095-6268-4e76-82c6-8dfc654ba8f0", "{ \"columns\": [ \"Kazım Balta\", \"Mehmetali Girgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 124, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 21, 17, 0, DateTimeKind.Unspecified) },
                    { "b3afd932-6039-46d0-9511-a535ba5949c5", "{ \"columns\": [ \"Ferdacan Aruca\", \"Hüseyin Serkan Erkekli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 77, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 11, 5, 27, 0, DateTimeKind.Unspecified) },
                    { "e38f9e0d-8110-4629-962d-d7c956f923ca", "{ \"columns\": [ \"Mustafa Burhan Askın\", \"Beniz Erkmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 79, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 3, 6, 59, 0, DateTimeKind.Unspecified) },
                    { "b4393e13-485f-4024-8d82-4f5d90448443", "{ \"columns\": [ \"Ilım Aslantürk\", \"Hasan Burak Erkoç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "527fdce4-0934-4973-b2f9-6877a75fcf09", "{ \"columns\": [ \"Sevginur Aşcı\", \"Selman Erkoşan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 81, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 10, 44, 52, 0, DateTimeKind.Unspecified) },
                    { "8911c122-9d44-4ef8-ba9b-561d744ca5be", "{ \"columns\": [ \"Hayrunnisa Aşveren\", \"Hanife Nur Erkovan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 82, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 7, 4, 7, 0, DateTimeKind.Unspecified) },
                    { "39fa9581-3341-4e0b-b32e-5a9cee0a7561", "{ \"columns\": [ \"Hanife Duygu Ata\", \"Alper Emin Erkuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 83, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 21, 9, 39, 27, 0, DateTimeKind.Unspecified) },
                    { "ab37b74d-367f-46f7-a5d8-411b516e9934", "{ \"columns\": [ \"Sevtap Atan\", \"Elif Kevser Eroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 84, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 16, 27, 28, 0, DateTimeKind.Unspecified) },
                    { "617914c0-1a7b-4f4a-ae86-137e6d93f439", "{ \"columns\": [ \"Paksoy Ateş\", \"Abdullah Mert Erol\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 85, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 13, 55, 21, 0, DateTimeKind.Unspecified) },
                    { "181850f7-6d51-414f-a904-a550ae0949b7", "{ \"columns\": [ \"İlkim Ateşcan\", \"Çisel Ersin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 86, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 15, 18, 22, 0, DateTimeKind.Unspecified) },
                    { "0949915e-c9f5-4f01-9da2-a2109882e60f", "{ \"columns\": [ \"Rubabe Gökçen Atlı\", \"İlkin Ersöz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 87, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 20, 11, 52, 0, DateTimeKind.Unspecified) },
                    { "04ad87e5-46a3-434a-ab32-d45e99e4a482", "{ \"columns\": [ \"Saba Atmaca\", \"Cantekin Erten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 88, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 21, 8, 1, 0, DateTimeKind.Unspecified) },
                    { "293fc83a-b5ce-4558-9353-f910bef3994d", "{ \"columns\": [ \"Çisem Atok\", \"Onur Kerem Ertepınar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 89, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 18, 8, 13, 0, DateTimeKind.Unspecified) },
                    { "99c993d6-6f8e-4215-b9f2-75105dcca10e", "{ \"columns\": [ \"Sabiha Elvan Atol\", \"İsmail Enes Eruzun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 90, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 19, 58, 20, 0, DateTimeKind.Unspecified) },
                    { "d337bde6-9612-4524-9823-e251e9e9edab", "{ \"columns\": [ \"Edip Attila\", \"Hamıd Eryıldız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 91, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 1, 5, 35, 0, DateTimeKind.Unspecified) },
                    { "d6639558-dabd-44d4-81ec-3cf89080ef02", "{ \"columns\": [ \"Şerife Asil\", \"İbrahim Candaş Erki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 78, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 14, 44, 48, 0, DateTimeKind.Unspecified) },
                    { "7ef114fa-5849-459c-a576-2ecb6e875642", "{ \"columns\": [ \"Seher İrem Çitfçi\", \"Naci Karakaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 249, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 2, 32, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
