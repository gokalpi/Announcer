using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Announcer.Data.Config
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id)
                   .HasName("PK_Notifications");

            builder.Property(n => n.Id)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.Content)
                   .IsRequired();

            builder.Property(n => n.SentTime)
                   .IsRequired();

            builder.Property(n => n.SenderId)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.GroupId);

            builder.Property(n => n.SenderId)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.RecipientId)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.HasIndex(n => n.GroupId);

            builder.HasIndex(n => n.RecipientId);

            builder.HasIndex(n => n.SenderId);

            builder.HasOne(n => n.Sender)
                .WithMany(c => c.NotificationsSent)
                .HasForeignKey(n => n.SenderId);

            builder.HasOne(n => n.Recipient)
                .WithMany(c => c.NotificationsReceived)
                .HasForeignKey(n => n.RecipientId)
                .IsRequired(false);

            builder.HasOne(n => n.Group)
                .WithMany(g => g.NotificationsReceived)
                .HasForeignKey(n => n.GroupId)
                .IsRequired(false);

            builder.HasData(
                new Notification() { Content = "{ \"columns\": [ \"Özde Acarkan\", \"Zülal Çolak\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-20T22:15:31"), GroupId = 2 },
                new Notification() { Content = "{ \"columns\": [ \"Atahan Adanır\", \"Ozan Ege Çomu\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-20T16:35:59"), GroupId = 3 },
                new Notification() { Content = "{ \"columns\": [ \"Hacı Mehmet Adıgüzel\", \"Hilal Ebru Çonay\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-21T10:08:37"), GroupId = 4 },
                new Notification() { Content = "{ \"columns\": [ \"Mükerrem Zeynep Ağca\", \"Ayben Çorumlu\" ] }", SenderId = "10.100.1.36", SentTime = DateTime.Parse("2020-04-20T19:52:00"), GroupId = 5 },
                new Notification() { Content = "{ \"columns\": [ \"Bestami Ağırağaç\", \"Abdulbaki Çotur\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-21T00:30:39"), GroupId = 6 },
                new Notification() { Content = "{ \"columns\": [ \"Aykanat Ağıroğlu\", \"Neva Çuhadar\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-21T06:58:40"), GroupId = 7 },
                new Notification() { Content = "{ \"columns\": [ \"Şennur Ağnar\", \"Öznur Çulhaoğlu\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-20T15:19:12"), GroupId = 8 },
                new Notification() { Content = "{ \"columns\": [ \"Tutkum Ahmadı Asl\", \"Olgun Dadalıoğlu\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-20T17:47:12"), GroupId = 9 },
                new Notification() { Content = "{ \"columns\": [ \"Mügenur Ahmet\", \"Çağrı Atahan Dağar\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-21T09:12:07"), GroupId = 10 },
                new Notification() { Content = "{ \"columns\": [ \"Sevinç Ak\", \"Özalp Dağbağ\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-21T10:36:01"), GroupId = 11 },
                new Notification() { Content = "{ \"columns\": [ \"Kayıhan Nedim Akarcalı\", \"Hüsne Aysun Dal\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-21T07:40:22"), GroupId = 12 },
                new Notification() { Content = "{ \"columns\": [ \"Fatma Özlem Acar\", \"Gürbüz Çivici\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-21T08:37:49"), GroupId = 1 },
                new Notification() { Content = "{ \"columns\": [ \"Lemi Akarçay\", \"Aydonat Dalkılıç\" ] }", SenderId = "10.100.1.35", SentTime = DateTime.Parse("2020-04-20T18:53:26"), GroupId = 13 },
                new Notification() { Content = "{ \"columns\": [ \"Cihan Akarpınar\", \"Ezgin Dallı\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-20T23:23:27"), GroupId = 14 },
                new Notification() { Content = "{ \"columns\": [ \"Rafi Akaş\", \"Refiye Seda Dalyaprak\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-21T00:20:26"), GroupId = 15 },
                new Notification() { Content = "{ \"columns\": [ \"Mehmetcan Akay\", \"Esat Erdem Daniş\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-20T19:59:39"), GroupId = 16 },
                new Notification() { Content = "{ \"columns\": [ \"Nuhaydar Akbilmez\", \"Ayşe Neslihan Daşdemir\" ] }", SenderId = "10.100.1.25", SentTime = DateTime.Parse("2020-04-20T19:06:32"), GroupId = 17 },
                new Notification() { Content = "{ \"columns\": [ \"Emine Münevver Akca\", \"Fetullah Davutoğlu\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-20T19:52:05"), GroupId = 18 },
                new Notification() { Content = "{ \"columns\": [ \"Servet Akçagunay\", \"Mert Görkem Dayıoğlu\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-20T13:06:22"), GroupId = 19 },
                new Notification() { Content = "{ \"columns\": [ \"Çilem Akçay\", \"Ergün Değirmendereli\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-20T13:07:17"), GroupId = 20 },
                new Notification() { Content = "{ \"columns\": [ \"Recep Ali Samet Akdoğan\", \"Hülya Delı Chasan\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-21T01:28:20"), GroupId = 21 },
                new Notification() { Content = "{ \"columns\": [ \"Emre Ayberk Akfırat\", \"Doga Elif Delice\" ] }", SenderId = "10.100.1.3", SentTime = DateTime.Parse("2020-04-20T23:12:45"), GroupId = 22 },
                new Notification() { Content = "{ \"columns\": [ \"Kerime Hacer Akıllı\", \"Muhammed Bazit Deliloğlu\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-21T07:07:46"), GroupId = 23 },
                new Notification() { Content = "{ \"columns\": [ \"Ercüment Akıncılar\", \"Miraç Demırören\" ] }", SenderId = "10.100.1.25", SentTime = DateTime.Parse("2020-04-20T19:21:16"), GroupId = 24 },
                new Notification() { Content = "{ \"columns\": [ \"Sarper Akış\", \"Hürel Demiriz\" ] }", SenderId = "10.100.1.38", SentTime = DateTime.Parse("2020-04-21T04:13:06"), GroupId = 25 },
                new Notification() { Content = "{ \"columns\": [ \"Berker Akkiray\", \"Sömer Demiroğlu\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-20T15:59:13"), GroupId = 26 },
                new Notification() { Content = "{ \"columns\": [ \"İclal Akkoyun\", \"Aysel Aysu Demirsatan\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-21T01:58:53"), GroupId = 27 },
                new Notification() { Content = "{ \"columns\": [ \"Lemis Akküt\", \"Mehmet Kemal Dengizek\" ] }", SenderId = "10.100.1.40", SentTime = DateTime.Parse("2020-04-20T20:51:09"), GroupId = 28 },
                new Notification() { Content = "{ \"columns\": [ \"Ahmet Polat Aklar Çörekçi\", \"Alya Denizgünü\" ] }", SenderId = "10.100.1.7", SentTime = DateTime.Parse("2020-04-21T09:03:37"), GroupId = 29 },
                new Notification() { Content = "{ \"columns\": [ \"Ata Kerem Akman\", \"Zeynep Büşra Derdemez\" ] }", SenderId = "10.100.1.35", SentTime = DateTime.Parse("2020-04-21T00:27:12"), GroupId = 30 },
                new Notification() { Content = "{ \"columns\": [ \"Ahmet Raşit Akoğuz\", \"Tubanur Dereli\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T10:14:11"), GroupId = 31 },
                new Notification() { Content = "{ \"columns\": [ \"Ecem Hatice Akova\", \"Dalay Derya\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T21:54:30"), GroupId = 32 },
                new Notification() { Content = "{ \"columns\": [ \"Nüket Aksan\", \"Bedir Destereci\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-21T07:55:50"), GroupId = 33 },
                new Notification() { Content = "{ \"columns\": [ \"Senem Aksevim\", \"Rümeysa İrem Devecel\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-21T06:21:36"), GroupId = 34 },
                new Notification() { Content = "{ \"columns\": [ \"Ayşen Aksoy\", \"Osman Sinan Devrim\" ] }", SenderId = "10.100.1.34", SentTime = DateTime.Parse("2020-04-20T18:25:29"), GroupId = 35 },
                new Notification() { Content = "{ \"columns\": [ \"Pekcan Aksöz\", \"Saliha Canan Dıvarcı\" ] }", SenderId = "10.100.1.38", SentTime = DateTime.Parse("2020-04-20T16:22:43"), GroupId = 36 },
                new Notification() { Content = "{ \"columns\": [ \"Bedirhan Lütfü Akşamoğlu\", \"Samet Emre Dikbaş\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-20T20:09:04"), GroupId = 37 },
                new Notification() { Content = "{ \"columns\": [ \"Semina Aktuna\", \"Haldun Dinçtürk\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T08:05:06"), GroupId = 38 },
                new Notification() { Content = "{ \"columns\": [ \"Eda Sena Akyıldız\", \"Goncagül Diri\" ] }", SenderId = "10.100.1.35", SentTime = DateTime.Parse("2020-04-21T10:11:27"), GroupId = 39 },
                new Notification() { Content = "{ \"columns\": [ \"Müyesser Akyildirim\", \"Ziya Doğramacı\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-21T00:26:45"), GroupId = 40 },
                new Notification() { Content = "{ \"columns\": [ \"Selinti Al\", \"Zehra Pelin Döger\" ] }", SenderId = "10.100.1.17", SentTime = DateTime.Parse("2020-04-21T09:03:34"), GroupId = 41 },
                new Notification() { Content = "{ \"columns\": [ \"Bahar Özlem Albaş\", \"Seli M Sharef Dökülmez\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-21T06:58:37"), GroupId = 42 },
                new Notification() { Content = "{ \"columns\": [ \"İlma Aldağ\", \"Firuze Dönder\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-21T09:48:44"), GroupId = 43 },
                new Notification() { Content = "{ \"columns\": [ \"Kutlu Alibeyoğlu\", \"Doruk Deniz Döner\" ] }", SenderId = "10.100.1.26", SentTime = DateTime.Parse("2020-04-20T15:40:02"), GroupId = 44 },
                new Notification() { Content = "{ \"columns\": [ \"Nesibe Nurefşan Alkan\", \"Çisil Zeynep Dönmez\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-20T22:15:28"), GroupId = 45 },
                new Notification() { Content = "{ \"columns\": [ \"Ömer Buğra Alparslan\", \"Tugce Dudu\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-20T16:14:54"), GroupId = 46 },
                new Notification() { Content = "{ \"columns\": [ \"Hiba Alpuğan\", \"Enver Dur\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-20T15:41:42"), GroupId = 47 },
                new Notification() { Content = "{ \"columns\": [ \"Mazlum Altan\", \"Sanber Durak\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-20T22:26:51"), GroupId = 48 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Tuğçe Altaş\", \"Birsen Durmuş\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-20T13:24:34"), GroupId = 49 },
                new Notification() { Content = "{ \"columns\": [ \"Ahmet Ruken Altay\", \"Taçmin Durmuşoğlu\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-21T01:18:06"), GroupId = 50 },
                new Notification() { Content = "{ \"columns\": [ \"Yaşar Utku Anıl Altın\", \"Karanalp Dursun\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-21T00:18:49"), GroupId = 51 },
                new Notification() { Content = "{ \"columns\": [ \"Rana Altınoklu\", \"Öktem Duymuş\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T23:08:31"), GroupId = 52 },
                new Notification() { Content = "{ \"columns\": [ \"Fethullah Altınöz\", \"Elanaz Dülgerbaki\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-20T19:28:29"), GroupId = 53 },
                new Notification() { Content = "{ \"columns\": [ \"Burak Tatkan Altıntaş\", \"Fidan Dündar\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-21T06:07:32"), GroupId = 54 },
                new Notification() { Content = "{ \"columns\": [ \"Merve Ece Altıok\", \"Barın Düşenkalkar\" ] }", SenderId = "10.100.1.25", SentTime = DateTime.Parse("2020-04-20T20:58:35"), GroupId = 55 },
                new Notification() { Content = "{ \"columns\": [ \"Rima Altıparmak\", \"Mehmet Erman Düzbayır\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-20T20:07:20"), GroupId = 56 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Dilay Altinkaya\", \"Cem Efe Edeş\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-21T11:06:33"), GroupId = 57 },
                new Notification() { Content = "{ \"columns\": [ \"Sırma Begüm Altunbaş\", \"Erem Edibali Mp\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-21T10:50:05"), GroupId = 58 },
                new Notification() { Content = "{ \"columns\": [ \"Nefse Altunbulak\", \"Volkan Eyüp Efşin\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-20T19:53:36"), GroupId = 59 },
                new Notification() { Content = "{ \"columns\": [ \"Büşra Gül Altundal\", \"İbrahim Alp Tekin Ege\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T15:13:58"), GroupId = 60 },
                new Notification() { Content = "{ \"columns\": [ \"Erna Aluç\", \"Güngör Erkin Egeli\" ] }", SenderId = "10.100.1.24", SentTime = DateTime.Parse("2020-04-20T15:53:04"), GroupId = 61 },
                new Notification() { Content = "{ \"columns\": [ \"Hikmet Nazlı Alver\", \"Çağın Egin\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T14:06:02"), GroupId = 62 },
                new Notification() { Content = "{ \"columns\": [ \"İsmail Umut Anık\", \"Alphan Ekercan\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-21T01:18:30"), GroupId = 63 },
                new Notification() { Content = "{ \"columns\": [ \"İlkay Ramazan Ankara\", \"Lale Ekrem\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-21T01:07:47"), GroupId = 64 },
                new Notification() { Content = "{ \"columns\": [ \"Nebahat Ansen\", \"Bağış Can Elbaşı\" ] }", SenderId = "10.100.1.3", SentTime = DateTime.Parse("2020-04-20T12:57:54"), GroupId = 65 },
                new Notification() { Content = "{ \"columns\": [ \"İlyas Umut Apul\", \"Mert Cem Eliçin\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-20T13:19:43"), GroupId = 66 },
                new Notification() { Content = "{ \"columns\": [ \"Halim Aral\", \"Ahmet Sencer Emikoğlu\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-21T08:34:17"), GroupId = 67 },
                new Notification() { Content = "{ \"columns\": [ \"Yasin Şükrü Arap\", \"Akife Erbay\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-20T16:16:45"), GroupId = 68 },
                new Notification() { Content = "{ \"columns\": [ \"Cansev Arat\", \"Burç Erbil\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T18:50:00"), GroupId = 69 },
                new Notification() { Content = "{ \"columns\": [ \"Memet Ali Ardıç\", \"Nadire Erbul\" ] }", SenderId = "10.100.1.40", SentTime = DateTime.Parse("2020-04-20T18:41:29"), GroupId = 70 },
                new Notification() { Content = "{ \"columns\": [ \"Deniz Dilay Arıcan\", \"Hüseyin Zeyd Ercoşkun\" ] }", SenderId = "10.100.1.7", SentTime = DateTime.Parse("2020-04-20T18:31:11"), GroupId = 71 },
                new Notification() { Content = "{ \"columns\": [ \"İzlem Arınç\", \"Aynur Gül Ercüment\" ] }", SenderId = "10.100.1.24", SentTime = DateTime.Parse("2020-04-21T07:54:01"), GroupId = 72 },
                new Notification() { Content = "{ \"columns\": [ \"Öget Arif\", \"Samed Erek\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-20T14:42:43"), GroupId = 73 },
                new Notification() { Content = "{ \"columns\": [ \"Şeyda Nur Arikan\", \"Cem Ozan Erim\" ] }", SenderId = "10.100.1.31", SentTime = DateTime.Parse("2020-04-21T07:38:18"), GroupId = 74 },
                new Notification() { Content = "{ \"columns\": [ \"Zeki Yiğithan Armutcu\", \"Bahar Cemre Erin\" ] }", SenderId = "10.100.1.21", SentTime = DateTime.Parse("2020-04-21T02:23:47"), GroupId = 75 },
                new Notification() { Content = "{ \"columns\": [ \"Nunazlı Arpacı\", \"Rekin Erkek\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T20:42:49"), GroupId = 76 },
                new Notification() { Content = "{ \"columns\": [ \"Ferdacan Aruca\", \"Hüseyin Serkan Erkekli\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T11:05:27"), GroupId = 77 },
                new Notification() { Content = "{ \"columns\": [ \"Şerife Asil\", \"İbrahim Candaş Erki\" ] }", SenderId = "10.100.1.3", SentTime = DateTime.Parse("2020-04-20T14:44:48"), GroupId = 78 },
                new Notification() { Content = "{ \"columns\": [ \"Mustafa Burhan Askın\", \"Beniz Erkmen\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-21T03:06:59"), GroupId = 79 },
                new Notification() { Content = "{ \"columns\": [ \"Ilım Aslantürk\", \"Hasan Burak Erkoç\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-20T15:06:02"), GroupId = 80 },
                new Notification() { Content = "{ \"columns\": [ \"Sevginur Aşcı\", \"Selman Erkoşan\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-21T10:44:52"), GroupId = 81 },
                new Notification() { Content = "{ \"columns\": [ \"Hayrunnisa Aşveren\", \"Hanife Nur Erkovan\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-21T07:04:07"), GroupId = 82 },
                new Notification() { Content = "{ \"columns\": [ \"Hanife Duygu Ata\", \"Alper Emin Erkuş\" ] }", SenderId = "10.100.1.41", SentTime = DateTime.Parse("2020-04-21T09:39:27"), GroupId = 83 },
                new Notification() { Content = "{ \"columns\": [ \"Sevtap Atan\", \"Elif Kevser Eroğlu\" ] }", SenderId = "10.100.1.6", SentTime = DateTime.Parse("2020-04-20T16:27:28"), GroupId = 84 },
                new Notification() { Content = "{ \"columns\": [ \"Paksoy Ateş\", \"Abdullah Mert Erol\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-20T13:55:21"), GroupId = 85 },
                new Notification() { Content = "{ \"columns\": [ \"İlkim Ateşcan\", \"Çisel Ersin\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-20T15:18:22"), GroupId = 86 },
                new Notification() { Content = "{ \"columns\": [ \"Rubabe Gökçen Atlı\", \"İlkin Ersöz\" ] }", SenderId = "10.100.1.41", SentTime = DateTime.Parse("2020-04-20T20:11:52"), GroupId = 87 },
                new Notification() { Content = "{ \"columns\": [ \"Saba Atmaca\", \"Cantekin Erten\" ] }", SenderId = "10.100.1.31", SentTime = DateTime.Parse("2020-04-20T21:08:01"), GroupId = 88 },
                new Notification() { Content = "{ \"columns\": [ \"Çisem Atok\", \"Onur Kerem Ertepınar\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-20T18:08:13"), GroupId = 89 },
                new Notification() { Content = "{ \"columns\": [ \"Sabiha Elvan Atol\", \"İsmail Enes Eruzun\" ] }", SenderId = "10.100.1.31", SentTime = DateTime.Parse("2020-04-20T19:58:20"), GroupId = 90 },
                new Notification() { Content = "{ \"columns\": [ \"Edip Attila\", \"Hamıd Eryıldız\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-21T01:05:35"), GroupId = 91 },
                new Notification() { Content = "{ \"columns\": [ \"Almina Avcı Özsoy\", \"Tunca Eryılmaz\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-20T14:28:53"), GroupId = 92 },
                new Notification() { Content = "{ \"columns\": [ \"Saime Avıandı\", \"Arslan Erzurumlu\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-21T07:31:25"), GroupId = 93 },
                new Notification() { Content = "{ \"columns\": [ \"Nehar Avşar\", \"Neslihan Buşra Esat\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-20T14:25:47"), GroupId = 94 },
                new Notification() { Content = "{ \"columns\": [ \"Kaan Muharrem Ay\", \"Lütfiye Sena Esen\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-20T16:42:17"), GroupId = 95 },
                new Notification() { Content = "{ \"columns\": [ \"Murat Kaan Ayanoglu\", \"Belin Esendemir\" ] }", SenderId = "10.100.1.26", SentTime = DateTime.Parse("2020-04-20T22:22:54"), GroupId = 96 },
                new Notification() { Content = "{ \"columns\": [ \"Murat Sinan Ayaz\", \"Rukiye Esgin\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-20T23:04:53"), GroupId = 97 },
                new Notification() { Content = "{ \"columns\": [ \"Ateş Aycı\", \"İslam Eshaqzada\" ] }", SenderId = "10.100.1.39", SentTime = DateTime.Parse("2020-04-20T14:29:28"), GroupId = 98 },
                new Notification() { Content = "{ \"columns\": [ \"Zeynep Nihan Aydınlıoğlu\", \"Batıray Eski\" ] }", SenderId = "10.100.1.31", SentTime = DateTime.Parse("2020-04-20T23:50:09"), GroupId = 99 },
                new Notification() { Content = "{ \"columns\": [ \"Kerime Aydoğan Yozgat\", \"Süheyl Esvap\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T14:19:34"), GroupId = 100 },
                new Notification() { Content = "{ \"columns\": [ \"Hami Aydoğdu\", \"Yargı Yekta Eşe\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-20T14:36:11"), GroupId = 101 },
                new Notification() { Content = "{ \"columns\": [ \"Thomas Aygen\", \"Elzem Evrenos\" ] }", SenderId = "10.100.1.21", SentTime = DateTime.Parse("2020-04-21T03:07:17"), GroupId = 102 },
                new Notification() { Content = "{ \"columns\": [ \"Güneş Aykan\", \"Ilgaz Eyipişiren\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-20T21:22:51"), GroupId = 103 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Feyza Ayrım\", \"Ongar Eyyupoğlu\" ] }", SenderId = "10.100.1.17", SentTime = DateTime.Parse("2020-04-20T15:03:26"), GroupId = 104 },
                new Notification() { Content = "{ \"columns\": [ \"Uğur Ali Aysal\", \"Faik Ezber\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-21T07:10:41"), GroupId = 105 },
                new Notification() { Content = "{ \"columns\": [ \"Osman Yasin Aysan\", \"Turan Fahri\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T08:40:27"), GroupId = 106 },
                new Notification() { Content = "{ \"columns\": [ \"Adem Ayvacık\", \"Okbay Fatih\" ] }", SenderId = "10.100.1.17", SentTime = DateTime.Parse("2020-04-20T23:33:16"), GroupId = 107 },
                new Notification() { Content = "{ \"columns\": [ \"Sera Cansın Azbay\", \"Latife Fatin\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-20T16:54:51"), GroupId = 108 },
                new Notification() { Content = "{ \"columns\": [ \"Ali İsmail Babacan\", \"Eyüp Orhun Fındık\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T23:48:48"), GroupId = 109 },
                new Notification() { Content = "{ \"columns\": [ \"Ruhugül Babadostu\", \"İrfan Anıl Fındıkçı\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-21T09:18:42"), GroupId = 110 },
                new Notification() { Content = "{ \"columns\": [ \"Alçiçek Bad\", \"Ertuğ Furuncuoğlu\" ] }", SenderId = "10.100.1.34", SentTime = DateTime.Parse("2020-04-20T13:30:15"), GroupId = 111 },
                new Notification() { Content = "{ \"columns\": [ \"Memet Bağcı\", \"Berhudan Garip\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-20T18:14:59"), GroupId = 112 },
                new Notification() { Content = "{ \"columns\": [ \"Mercan Bağçivan\", \"Nihan Gazitepe\" ] }", SenderId = "10.100.1.39", SentTime = DateTime.Parse("2020-04-20T11:28:35"), GroupId = 113 },
                new Notification() { Content = "{ \"columns\": [ \"Gökay Bağış\", \"Menekşe Geben\" ] }", SenderId = "10.100.1.7", SentTime = DateTime.Parse("2020-04-20T21:17:54"), GroupId = 114 },
                new Notification() { Content = "{ \"columns\": [ \"Pırıltı Bahçeli\", \"Şeniz Geboloğlu\" ] }", SenderId = "10.100.1.3", SentTime = DateTime.Parse("2020-04-20T13:24:53"), GroupId = 115 },
                new Notification() { Content = "{ \"columns\": [ \"Özgün Bahtıyar\", \"Zeynep Senahan Geçioğlu\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T13:08:53"), GroupId = 116 },
                new Notification() { Content = "{ \"columns\": [ \"Özgen Baka\", \"Hayri Anıl Geçkin\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T22:39:00"), GroupId = 117 },
                new Notification() { Content = "{ \"columns\": [ \"Seung Hun Baki\", \"Muazzez Ece Gemalmaz\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-20T19:24:30"), GroupId = 118 },
                new Notification() { Content = "{ \"columns\": [ \"Gülser Bal\", \"Kerem Cahit Gençoğlu\" ] }", SenderId = "10.100.1.35", SentTime = DateTime.Parse("2020-04-20T17:38:04"), GroupId = 119 },
                new Notification() { Content = "{ \"columns\": [ \"Yüksel Balcı\", \"Sadık Can Gezmiş\" ] }", SenderId = "10.100.1.12", SentTime = DateTime.Parse("2020-04-21T03:41:25"), GroupId = 120 },
                new Notification() { Content = "{ \"columns\": [ \"Ecren Baldo\", \"Resmiye Elif Gırgın\" ] }", SenderId = "10.100.1.19", SentTime = DateTime.Parse("2020-04-20T17:32:20"), GroupId = 121 },
                new Notification() { Content = "{ \"columns\": [ \"Muhammet Raşit Balı\", \"Nergiz Gilim\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-20T17:03:38"), GroupId = 122 },
                new Notification() { Content = "{ \"columns\": [ \"Sakıp Balıoğlu\", \"Mehmet Gökalp Ginoviç\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-21T09:42:35"), GroupId = 123 },
                new Notification() { Content = "{ \"columns\": [ \"Kazım Balta\", \"Mehmetali Girgin\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-20T13:21:17"), GroupId = 124 },
                new Notification() { Content = "{ \"columns\": [ \"Abdullah Atakan Baluken\", \"Abdullah Halit Golba\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-21T11:02:58"), GroupId = 125 },
                new Notification() { Content = "{ \"columns\": [ \"Coşkun Baran\", \"Tilbe Göç\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-20T21:11:38"), GroupId = 126 },
                new Notification() { Content = "{ \"columns\": [ \"Serdar Kaan Barbaros\", \"Kubra Göçmen\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T17:10:06"), GroupId = 127 },
                new Notification() { Content = "{ \"columns\": [ \"Ezel Bargan\", \"Kubilay Gödek\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-21T06:49:28"), GroupId = 128 },
                new Notification() { Content = "{ \"columns\": [ \"Ayşegül Barutçuoğlu\", \"Busem Gökçeaslan\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-21T01:58:28"), GroupId = 129 },
                new Notification() { Content = "{ \"columns\": [ \"Sefa Kadir Başar\", \"Banuhan Gökçek\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-21T06:15:21"), GroupId = 130 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Etga Başeğmez\", \"Örgün Gökhan\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-21T02:03:20"), GroupId = 131 },
                new Notification() { Content = "{ \"columns\": [ \"Balın Baştepe\", \"Melike Göksoy\" ] }", SenderId = "10.100.1.17", SentTime = DateTime.Parse("2020-04-20T23:42:08"), GroupId = 132 },
                new Notification() { Content = "{ \"columns\": [ \"Mahperi Baştopçu\", \"Yeşim Gölmes\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-20T19:26:28"), GroupId = 133 },
                new Notification() { Content = "{ \"columns\": [ \"Erol Özgür Baştuğ\", \"Nilüfer Gönay\" ] }", SenderId = "10.100.1.31", SentTime = DateTime.Parse("2020-04-20T22:39:49"), GroupId = 134 },
                new Notification() { Content = "{ \"columns\": [ \"Atak Batar\", \"Denizhan Gönül\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-21T10:10:33"), GroupId = 135 },
                new Notification() { Content = "{ \"columns\": [ \"Safa Batga\", \"Şueda Göreke\" ] }", SenderId = "10.100.1.25", SentTime = DateTime.Parse("2020-04-21T05:06:53"), GroupId = 136 },
                new Notification() { Content = "{ \"columns\": [ \"Gökmen Battal\", \"Ersin Görgülü\" ] }", SenderId = "10.100.1.24", SentTime = DateTime.Parse("2020-04-20T18:07:24"), GroupId = 137 },
                new Notification() { Content = "{ \"columns\": [ \"Fazıl Erem Batuk\", \"Şahabettin Görgüner\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T22:50:59"), GroupId = 138 },
                new Notification() { Content = "{ \"columns\": [ \"Bensu Batur\", \"Ayşe Elif Görür\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-21T08:15:40"), GroupId = 139 },
                new Notification() { Content = "{ \"columns\": [ \"Nazım Orhun Baturalp\", \"Nazım Berke Göven\" ] }", SenderId = "10.100.1.39", SentTime = DateTime.Parse("2020-04-21T02:59:02"), GroupId = 140 },
                new Notification() { Content = "{ \"columns\": [ \"Safa Ahmet Baydar\", \"Meltem Göymen\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-21T04:37:28"), GroupId = 141 },
                new Notification() { Content = "{ \"columns\": [ \"Demircan Baydil\", \"Abdulhalim Guguk\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T16:00:53"), GroupId = 142 },
                new Notification() { Content = "{ \"columns\": [ \"Burçin Kübra Baykal\", \"Gülten Güdücü\" ] }", SenderId = "10.100.1.6", SentTime = DateTime.Parse("2020-04-20T12:19:44"), GroupId = 143 },
                new Notification() { Content = "{ \"columns\": [ \"Derviş Haluk Baykan\", \"Işınbıke Gülcan\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-20T19:00:58"), GroupId = 144 },
                new Notification() { Content = "{ \"columns\": [ \"Taylan Remzi Baykuş\", \"Vedia Gülçin\" ] }", SenderId = "10.100.1.40", SentTime = DateTime.Parse("2020-04-21T11:03:45"), GroupId = 145 },
                new Notification() { Content = "{ \"columns\": [ \"Abdulvahap Bayrakoğlu\", \"Fatma Sena Güldoğuş\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-21T08:34:23"), GroupId = 146 },
                new Notification() { Content = "{ \"columns\": [ \"Aygün Bayram\", \"Ömer Okan Gülebakan\" ] }", SenderId = "10.100.1.6", SentTime = DateTime.Parse("2020-04-20T13:16:12"), GroupId = 147 },
                new Notification() { Content = "{ \"columns\": [ \"Ayla Baytın\", \"Aybike Güleç\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T14:28:27"), GroupId = 148 },
                new Notification() { Content = "{ \"columns\": [ \"Kubilay Barış Begiç\", \"Bektaş Gülenç\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-20T19:06:49"), GroupId = 149 },
                new Notification() { Content = "{ \"columns\": [ \"Mustafa Samed Beğenilmiş\", \"Emircan Güleryüz\" ] }", SenderId = "10.100.1.19", SentTime = DateTime.Parse("2020-04-20T17:20:37"), GroupId = 150 },
                new Notification() { Content = "{ \"columns\": [ \"Berfin Dilay Bekaroğlu\", \"Merter Gülkan\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-20T14:53:12"), GroupId = 151 },
                new Notification() { Content = "{ \"columns\": [ \"İbrahim Onat Belge\", \"Sevgi Tutku Güllüce\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-21T10:45:07"), GroupId = 152 },
                new Notification() { Content = "{ \"columns\": [ \"Jutenya Benan\", \"Denktaş Gülşen\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-20T21:14:22"), GroupId = 153 },
                new Notification() { Content = "{ \"columns\": [ \"Hulki Bent\", \"Köksal Gültaş\" ] }", SenderId = "10.100.1.20", SentTime = DateTime.Parse("2020-04-21T08:35:26"), GroupId = 154 },
                new Notification() { Content = "{ \"columns\": [ \"Mustafa Doğukan Berberoğlu\", \"Hasan Fahri Gültepe\" ] }", SenderId = "10.100.1.34", SentTime = DateTime.Parse("2020-04-20T14:44:16"), GroupId = 155 },
                new Notification() { Content = "{ \"columns\": [ \"Hüner Berk\", \"Öymen Gümüşsoy\" ] }", SenderId = "10.100.1.41", SentTime = DateTime.Parse("2020-04-20T21:14:45"), GroupId = 156 },
                new Notification() { Content = "{ \"columns\": [ \"Buse Gizem Berker\", \"Eylem Gündüz\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-20T19:18:10"), GroupId = 157 },
                new Notification() { Content = "{ \"columns\": [ \"Halime Beydağ\", \"Melek Diler Günel\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-21T07:27:34"), GroupId = 158 },
                new Notification() { Content = "{ \"columns\": [ \"Didem Bıçaksız\", \"Argun Güneri\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T17:59:08"), GroupId = 159 },
                new Notification() { Content = "{ \"columns\": [ \"Mihrinaz Bilal\", \"Mehmet Yekta Güneyi\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-21T10:09:50"), GroupId = 160 },
                new Notification() { Content = "{ \"columns\": [ \"Lal Bilgeç\", \"Yasemin Erva Güntek\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T10:51:53"), GroupId = 161 },
                new Notification() { Content = "{ \"columns\": [ \"Senay Bilgen\", \"Günan Güral\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-21T04:59:42"), GroupId = 162 },
                new Notification() { Content = "{ \"columns\": [ \"Remzi Bilgi\", \"Osman Cihan Gürdemir\" ] }", SenderId = "10.100.1.21", SentTime = DateTime.Parse("2020-04-20T20:19:59"), GroupId = 163 },
                new Notification() { Content = "{ \"columns\": [ \"Armağan Bilgiç\", \"Okyanus Gürel\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-21T05:27:45"), GroupId = 164 },
                new Notification() { Content = "{ \"columns\": [ \"Çelik Bilgir\", \"Mert Alican Güreş\" ] }", SenderId = "10.100.1.38", SentTime = DateTime.Parse("2020-04-21T10:59:36"), GroupId = 165 },
                new Notification() { Content = "{ \"columns\": [ \"Kübra Tansu Bilgit\", \"Zeynep Doğa Gürses\" ] }", SenderId = "10.100.1.6", SentTime = DateTime.Parse("2020-04-20T17:51:08"), GroupId = 166 },
                new Notification() { Content = "{ \"columns\": [ \"Uluç Emre Binbay\", \"Tarık Güven\" ] }", SenderId = "10.100.1.41", SentTime = DateTime.Parse("2020-04-20T15:15:26"), GroupId = 167 },
                new Notification() { Content = "{ \"columns\": [ \"Mehmet Buğrahan Birgili\", \"Birgen Güvener\" ] }", SenderId = "10.100.1.25", SentTime = DateTime.Parse("2020-04-20T16:22:55"), GroupId = 168 },
                new Notification() { Content = "{ \"columns\": [ \"Doğuşcan Biriz\", \"Ahmet Korhan Güzel\" ] }", SenderId = "10.100.1.37", SentTime = DateTime.Parse("2020-04-21T05:25:15"), GroupId = 169 },
                new Notification() { Content = "{ \"columns\": [ \"Altan Boy\", \"Manolya Güzeller\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T12:32:18"), GroupId = 170 },
                new Notification() { Content = "{ \"columns\": [ \"Bengisu Boya\", \"Mustafa Berkay Güzeloğlu\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T14:13:55"), GroupId = 171 },
                new Notification() { Content = "{ \"columns\": [ \"Onur Taylan Boylu\", \"Mehmet Anıl Hacıalioğlu\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-21T03:34:43"), GroupId = 172 },
                new Notification() { Content = "{ \"columns\": [ \"Ayseren Boyuktaş\", \"Ahmet Furkan Hacılar\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-20T19:01:09"), GroupId = 173 },
                new Notification() { Content = "{ \"columns\": [ \"Pekin Boz\", \"Fazilet Hacıoğlu\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-21T10:56:21"), GroupId = 174 },
                new Notification() { Content = "{ \"columns\": [ \"Aksu Bozdağ\", \"Kıvılcım Hadi\" ] }", SenderId = "10.100.1.23", SentTime = DateTime.Parse("2020-04-20T12:04:49"), GroupId = 175 },
                new Notification() { Content = "{ \"columns\": [ \"Arkan Bozdemir\", \"Çisil Hazal Hafız\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-20T19:31:34"), GroupId = 176 },
                new Notification() { Content = "{ \"columns\": [ \"İltem Boztepe\", \"Feray Hakverdi\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-21T01:38:54"), GroupId = 177 },
                new Notification() { Content = "{ \"columns\": [ \"Betül Bozyer\", \"Büşranur Halaçoğlu\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-21T08:00:21"), GroupId = 178 },
                new Notification() { Content = "{ \"columns\": [ \"Ogün Bölge\", \"Selin Sıla Halıcılar\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-20T18:21:57"), GroupId = 179 },
                new Notification() { Content = "{ \"columns\": [ \"İbrahim Hakkı Bugey\", \"Yeter Hamamcıoğlu\" ] }", SenderId = "10.100.1.24", SentTime = DateTime.Parse("2020-04-21T03:42:01"), GroupId = 180 },
                new Notification() { Content = "{ \"columns\": [ \"Onay Buğdaypınarı\", \"Ramazan Tarık Hamarat\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T13:37:52"), GroupId = 181 },
                new Notification() { Content = "{ \"columns\": [ \"Cankız Bulgan\", \"Boran Hamidi\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-21T04:19:58"), GroupId = 182 },
                new Notification() { Content = "{ \"columns\": [ \"Arzucan Bulgur\", \"Tazika Hilal Hamzaoğlu\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T22:40:51"), GroupId = 183 },
                new Notification() { Content = "{ \"columns\": [ \"Asiye Burabak\", \"Aynur Dilan Hancı\" ] }", SenderId = "10.100.1.12", SentTime = DateTime.Parse("2020-04-21T02:08:47"), GroupId = 184 },
                new Notification() { Content = "{ \"columns\": [ \"Ahmet Yasin Burak\", \"Ayman Hangül\" ] }", SenderId = "10.100.1.6", SentTime = DateTime.Parse("2020-04-21T02:50:44"), GroupId = 185 },
                new Notification() { Content = "{ \"columns\": [ \"Yaprak Bural\", \"Berrak Harman\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-20T22:10:53"), GroupId = 186 },
                new Notification() { Content = "{ \"columns\": [ \"Aleda Buyuran\", \"Erk Deha Harmankaya\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-21T09:00:41"), GroupId = 187 },
                new Notification() { Content = "{ \"columns\": [ \"Can Güney Bülbül\", \"Perihan Haykır\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-21T11:04:40"), GroupId = 188 },
                new Notification() { Content = "{ \"columns\": [ \"Mahmut Bilal Bülend\", \"Turhan Onur Hırlak\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-21T08:28:45"), GroupId = 189 },
                new Notification() { Content = "{ \"columns\": [ \"Saliha Zeynep Bülent\", \"Furkan Hızarcıoğlu\" ] }", SenderId = "10.100.1.15", SentTime = DateTime.Parse("2020-04-21T07:58:41"), GroupId = 190 },
                new Notification() { Content = "{ \"columns\": [ \"Melike Dilara Büyükfırat\", \"Mustafa Ali Hiçyılmam\" ] }", SenderId = "10.100.1.12", SentTime = DateTime.Parse("2020-04-20T18:15:00"), GroupId = 191 },
                new Notification() { Content = "{ \"columns\": [ \"Hayriye Büyükgüngör\", \"Muhammed Sefa Hilal\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T12:45:42"), GroupId = 192 },
                new Notification() { Content = "{ \"columns\": [ \"Sebiha Büyüköztürk\", \"Argün Hilmi\" ] }", SenderId = "10.100.1.40", SentTime = DateTime.Parse("2020-04-21T10:25:56"), GroupId = 193 },
                new Notification() { Content = "{ \"columns\": [ \"Mehmet Can Akçaözoğlu\", \"Fadik Himoğlu\" ] }", SenderId = "10.100.1.26", SentTime = DateTime.Parse("2020-04-21T03:57:41"), GroupId = 194 },
                new Notification() { Content = "{ \"columns\": [ \"Mehmet Enes Canan\", \"Ahmet Hakkı Hirik\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-21T09:08:41"), GroupId = 195 },
                new Notification() { Content = "{ \"columns\": [ \"Kurtbey Canbağı\", \"Mustafa Sefa Hopacı\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-21T10:35:32"), GroupId = 196 },
                new Notification() { Content = "{ \"columns\": [ \"Mustafa Taha Canbek\", \"Toykan Horata\" ] }", SenderId = "10.100.1.41", SentTime = DateTime.Parse("2020-04-20T14:38:48"), GroupId = 197 },
                new Notification() { Content = "{ \"columns\": [ \"Sena Nur Candan\", \"Selime Hüner\" ] }", SenderId = "10.100.1.39", SentTime = DateTime.Parse("2020-04-21T04:51:29"), GroupId = 198 },
                new Notification() { Content = "{ \"columns\": [ \"Abdullah Emirhan Caner\", \"Denizcan Ilık\" ] }", SenderId = "10.100.1.40", SentTime = DateTime.Parse("2020-04-20T23:44:06"), GroupId = 199 },
                new Notification() { Content = "{ \"columns\": [ \"Mustafa Kerem Cansu\", \"Ayşe Zeyneb Irıcıoğlu\" ] }", SenderId = "10.100.1.14", SentTime = DateTime.Parse("2020-04-20T13:34:02"), GroupId = 200 },
                new Notification() { Content = "{ \"columns\": [ \"Doktora Canuyar\", \"Mustafa Furkan Işınay\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T11:16:38"), GroupId = 201 },
                new Notification() { Content = "{ \"columns\": [ \"Seyit Ceran\", \"Sude İbrahim\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-20T17:47:59"), GroupId = 202 },
                new Notification() { Content = "{ \"columns\": [ \"Selma Simge Ceylan\", \"Güçlü İçten\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-21T09:30:08"), GroupId = 203 },
                new Notification() { Content = "{ \"columns\": [ \"Aşkım Chiklyaukova\", \"Katya İlgezdi\" ] }", SenderId = "10.100.1.17", SentTime = DateTime.Parse("2020-04-21T04:49:51"), GroupId = 204 },
                new Notification() { Content = "{ \"columns\": [ \"Özgür Choi\", \"Halid İlhan\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-20T16:03:04"), GroupId = 205 },
                new Notification() { Content = "{ \"columns\": [ \"Tuğce Cibooğlu\", \"Nihal İlısu\" ] }", SenderId = "10.100.1.7", SentTime = DateTime.Parse("2020-04-21T09:57:28"), GroupId = 206 },
                new Notification() { Content = "{ \"columns\": [ \"Özer Seçkin Ciddi\", \"Elif Nisan İmamoğlu\" ] }", SenderId = "10.100.1.21", SentTime = DateTime.Parse("2020-04-20T16:36:14"), GroupId = 207 },
                new Notification() { Content = "{ \"columns\": [ \"Balkın Cigerlioğlu\", \"Emine Selcen İmre\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T20:26:52"), GroupId = 208 },
                new Notification() { Content = "{ \"columns\": [ \"Yücel Civan\", \"Tevfik İnal\" ] }", SenderId = "10.100.1.1", SentTime = DateTime.Parse("2020-04-21T11:04:02"), GroupId = 209 },
                new Notification() { Content = "{ \"columns\": [ \"Şansal Coşan\", \"İbrahim Kağan İncekara\" ] }", SenderId = "10.100.1.24", SentTime = DateTime.Parse("2020-04-20T19:51:38"), GroupId = 210 },
                new Notification() { Content = "{ \"columns\": [ \"Oğuzcan Coşandal\", \"Sidar İnceoğlu\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-21T06:14:55"), GroupId = 211 },
                new Notification() { Content = "{ \"columns\": [ \"Mayıs Cumalı\", \"Nesli İpçizade\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-20T16:19:36"), GroupId = 212 },
                new Notification() { Content = "{ \"columns\": [ \"Büşra Cüce\", \"İhsan Vehbi İpekoğlu\" ] }", SenderId = "10.100.1.38", SentTime = DateTime.Parse("2020-04-21T08:28:52"), GroupId = 213 },
                new Notification() { Content = "{ \"columns\": [ \"Afra Selcen Çağan\", \"Necati İrsoy\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-21T07:07:59"), GroupId = 214 },
                new Notification() { Content = "{ \"columns\": [ \"Gönül Çağatay\", \"Zerin İshakoğlu\" ] }", SenderId = "10.100.1.28", SentTime = DateTime.Parse("2020-04-21T04:59:44"), GroupId = 215 },
                new Notification() { Content = "{ \"columns\": [ \"Doğangün Çağlar\", \"Dursun Korel İşgören\" ] }", SenderId = "10.100.1.26", SentTime = DateTime.Parse("2020-04-20T14:06:11"), GroupId = 216 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Ege Çağlayan\", \"Ahuşen İşgüzar\" ] }", SenderId = "10.100.1.33", SentTime = DateTime.Parse("2020-04-20T23:43:16"), GroupId = 217 },
                new Notification() { Content = "{ \"columns\": [ \"Özen Çakan\", \"Uzel Kabataş\" ] }", SenderId = "10.100.1.19", SentTime = DateTime.Parse("2020-04-20T11:53:06"), GroupId = 218 },
                new Notification() { Content = "{ \"columns\": [ \"Dilhan Çakanel\", \"Melis Ezgi Kabayuka\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-21T01:11:58"), GroupId = 219 },
                new Notification() { Content = "{ \"columns\": [ \"Maral Çakıcı\", \"Şaziye Kabukçu\" ] }", SenderId = "10.100.1.39", SentTime = DateTime.Parse("2020-04-20T20:21:01"), GroupId = 220 },
                new Notification() { Content = "{ \"columns\": [ \"Mahire Çalım\", \"Bergüzar Kaçaranoğlu\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-21T10:18:45"), GroupId = 221 },
                new Notification() { Content = "{ \"columns\": [ \"Hacı Bayram Ufuk Çamaş\", \"Ömer Faruk Kadı\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-20T12:13:48"), GroupId = 222 },
                new Notification() { Content = "{ \"columns\": [ \"Oltun Çanga\", \"Dağhan Kadoğlu\" ] }", SenderId = "10.100.1.7", SentTime = DateTime.Parse("2020-04-20T19:24:58"), GroupId = 223 },
                new Notification() { Content = "{ \"columns\": [ \"Önel Çapa\", \"Ünzile Kalfaoğlu\" ] }", SenderId = "10.100.1.36", SentTime = DateTime.Parse("2020-04-21T08:36:10"), GroupId = 224 },
                new Notification() { Content = "{ \"columns\": [ \"Bayülken Çaprak\", \"Sezer Kalsın\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-21T03:12:24"), GroupId = 225 },
                new Notification() { Content = "{ \"columns\": [ \"Dilseren Çarıcı\", \"Şensoy Kalyoncu\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-20T14:32:23"), GroupId = 226 },
                new Notification() { Content = "{ \"columns\": [ \"Elif Beyza Çark\", \"Necatı Kamışlı\" ] }", SenderId = "10.100.1.16", SentTime = DateTime.Parse("2020-04-20T11:44:37"), GroupId = 227 },
                new Notification() { Content = "{ \"columns\": [ \"Elvan Çatal\", \"Şahan Kandaşoğlu\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-20T17:47:12"), GroupId = 228 },
                new Notification() { Content = "{ \"columns\": [ \"Esim Çaylar\", \"Necip Fazıl Kanlı\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-20T11:38:41"), GroupId = 229 },
                new Notification() { Content = "{ \"columns\": [ \"Sena Çekmecelioğlu\", \"Muharrem Kanmaz\" ] }", SenderId = "10.100.1.34", SentTime = DateTime.Parse("2020-04-21T02:33:17"), GroupId = 230 },
                new Notification() { Content = "{ \"columns\": [ \"Muhammed Üzeyir Çekmeci\", \"Zeynep Figen Kantarcı\" ] }", SenderId = "10.100.1.11", SentTime = DateTime.Parse("2020-04-21T06:00:56"), GroupId = 231 },
                new Notification() { Content = "{ \"columns\": [ \"Aydın Mert Çelebican\", \"Çilay Kapsız\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-21T10:08:25"), GroupId = 232 },
                new Notification() { Content = "{ \"columns\": [ \"Çağkan Çelenlioğlu\", \"Suna Karaaslanlı\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T14:17:11"), GroupId = 233 },
                new Notification() { Content = "{ \"columns\": [ \"Zümra Çelık\", \"Ahmet Can Karabacak\" ] }", SenderId = "10.100.1.8", SentTime = DateTime.Parse("2020-04-20T18:20:41"), GroupId = 234 },
                new Notification() { Content = "{ \"columns\": [ \"Bayar Çelik\", \"Asya Sema Karabağ\" ] }", SenderId = "10.100.1.4", SentTime = DateTime.Parse("2020-04-21T03:54:02"), GroupId = 235 },
                new Notification() { Content = "{ \"columns\": [ \"Gönülgül Çelikağı\", \"Gül Sena Karabıyık\" ] }", SenderId = "10.100.1.12", SentTime = DateTime.Parse("2020-04-21T01:17:39"), GroupId = 236 },
                new Notification() { Content = "{ \"columns\": [ \"Ece Pınar Çeliker\", \"Fatma Büşra Karabıyıklı\" ] }", SenderId = "10.100.1.21", SentTime = DateTime.Parse("2020-04-21T06:26:51"), GroupId = 237 },
                new Notification() { Content = "{ \"columns\": [ \"Mehmet Tarık Çelikkol\", \"Arca Karabulut\" ] }", SenderId = "10.100.1.29", SentTime = DateTime.Parse("2020-04-21T10:07:29"), GroupId = 238 },
                new Notification() { Content = "{ \"columns\": [ \"Elife Çerçi\", \"Abdullatif Karacabey\" ] }", SenderId = "10.100.1.27", SentTime = DateTime.Parse("2020-04-21T06:06:10"), GroupId = 239 },
                new Notification() { Content = "{ \"columns\": [ \"Efecan Çetintaş\", \"Tuğra Karacan\" ] }", SenderId = "10.100.1.10", SentTime = DateTime.Parse("2020-04-21T06:32:13"), GroupId = 240 },
                new Notification() { Content = "{ \"columns\": [ \"Rıdvan Çıkıkcı\", \"Emir Doğan Karaçay\" ] }", SenderId = "10.100.1.2", SentTime = DateTime.Parse("2020-04-21T07:58:42"), GroupId = 241 },
                new Notification() { Content = "{ \"columns\": [ \"Hatice Gamze Çınar\", \"Haluk Barış Karaçeşme\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-21T03:08:19"), GroupId = 242 },
                new Notification() { Content = "{ \"columns\": [ \"Yansı Hilal Çınaroğlu\", \"Seyit Ahmet Karadağ\" ] }", SenderId = "10.100.1.30", SentTime = DateTime.Parse("2020-04-21T09:57:51"), GroupId = 243 },
                new Notification() { Content = "{ \"columns\": [ \"Omaç Çıngır\", \"Cevza Karadalan\" ] }", SenderId = "10.100.1.36", SentTime = DateTime.Parse("2020-04-21T04:22:52"), GroupId = 244 },
                new Notification() { Content = "{ \"columns\": [ \"Erhan Çıray\", \"Mustafa Emir Karademir\" ] }", SenderId = "10.100.1.32", SentTime = DateTime.Parse("2020-04-20T23:13:26"), GroupId = 245 },
                new Notification() { Content = "{ \"columns\": [ \"Şüheda Çiçekli\", \"Ilgar Pamir Karaismail\" ] }", SenderId = "10.100.1.18", SentTime = DateTime.Parse("2020-04-21T01:10:50"), GroupId = 246 },
                new Notification() { Content = "{ \"columns\": [ \"Ünkan Çini\", \"Seren Karakan\" ] }", SenderId = "10.100.1.9", SentTime = DateTime.Parse("2020-04-21T08:17:32"), GroupId = 247 },
                new Notification() { Content = "{ \"columns\": [ \"Ahmet Gazi Çintan\", \"Büşra Hazal Karakaplan\" ] }", SenderId = "10.100.1.13", SentTime = DateTime.Parse("2020-04-20T21:29:21"), GroupId = 248 },
                new Notification() { Content = "{ \"columns\": [ \"Seher İrem Çitfçi\", \"Naci Karakaya\" ] }", SenderId = "10.100.1.22", SentTime = DateTime.Parse("2020-04-21T04:02:32"), GroupId = 249 }
                );
        }
    }
}