namespace HashSlinger.Api.Utilities;

using Models;

/// <summary>
/// Contains methods to seed the database with data.
/// </summary>
public static class SeedTool
{
    public static List<HashType> GetHashTypeSeeds()
    {
        return new List<HashType>()
        {
            new HashType { HashcatId = 0, Description = "MD5", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 10, Description = "md5($pass.$salt)", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11, Description = "Joomla < 2.5.18", IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 12, Description = "PostgreSQL", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 20, Description = "md5($salt.$pass)", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21, Description = "osCommerce, xt:Commerce", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22, Description = "Juniper Netscreen/SSG (ScreenOS)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 23, Description = "Skype", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 24, Description = "SolarWinds Serv-U", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 30, Description = "md5(utf16le($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 40, Description = "md5($salt.utf16le($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 50, Description = "HMAC-MD5 (key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 60, Description = "HMAC-MD5 (key = $salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 70, Description = "md5(utf16le($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 100, Description = "SHA1", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 101, Description = "nsldap, SHA-1(Base64}, Netscape LDAP SHA",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 110, Description = "sha1($pass.$salt)", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 111, Description = "nsldaps, SSHA-1(Base64}, Netscape LDAP SSHA",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 112, Description = "Oracle S: Type (Oracle 11+)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 120, Description = "sha1($salt.$pass)", IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 121, Description = "SMF >= v1.1", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 122, Description = "OS X v10.4, v10.5, v10.6", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 124, Description = "Django (SHA-1)", IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 125, Description = "ArubaOS", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 130, Description = "sha1(utf16le($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 131, Description = "MSSQL(2000)", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 132, Description = "MSSQL(2005)", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 133, Description = "PeopleSoft", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 140, Description = "sha1($salt.utf16le($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 141, Description = "EPiServer 6.x < v4", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 150, Description = "HMAC-SHA1 (key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 160, Description = "HMAC-SHA1 (key = $salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 170, Description = "sha1(utf16le($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 200, Description = "MySQL323", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 300, Description = "MySQL4.1/MySQL5+", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 400, Description = "phpass, MD5(Wordpress}, MD5(Joomla}, MD5(phpBB3)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 500, Description = "md5crypt, MD5(Unix}, FreeBSD MD5, Cisco-IOS MD5 2",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 501, Description = "Juniper IVE", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 600, Description = "BLAKE2b-512", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 610, Description = "BLAKE2b-512($pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 620, Description = "BLAKE2b-512($salt.$pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 900, Description = "MD4", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 1000, Description = "NTLM", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 1100, Description = "Domain Cached Credentials (DCC}, MS Cache",
                IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 1300, Description = "SHA-224", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 1400, Description = "SHA256", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 1410, Description = "sha256($pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1411, Description = "SSHA-256(Base64}, LDAP {SSHA256}", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1420, Description = "sha256($salt.$pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1421, Description = "hMailServer", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1430, Description = "sha256(utf16le($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1440, Description = "sha256($salt.utf16le($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1441, Description = "EPiServer 6.x >= v4", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1450, Description = "HMAC-SHA256 (key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1460, Description = "HMAC-SHA256 (key = $salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1470, Description = "sha256(utf16le($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1500, Description = "descrypt, DES(Unix}, Traditional DES",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1600, Description = "md5apr1, MD5(APR}, Apache MD5", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 1700, Description = "SHA512", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 1710, Description = "sha512($pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1711, Description = "SSHA-512(Base64}, LDAP {SSHA512}", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1720, Description = "sha512($salt.$pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 1722, Description = "OS X v10.7", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 1730, Description = "sha512(utf16le($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1731, Description = "MSSQL(2012}, MSSQL(2014)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1740, Description = "sha512($salt.utf16le($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1750, Description = "HMAC-SHA512 (key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1760, Description = "HMAC-SHA512 (key = $salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1770, Description = "sha512(utf16le($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 1800, Description = "sha512crypt, SHA512(Unix)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 2000, Description = "STDOUT", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 2100, Description = "Domain Cached Credentials 2 (DCC2}, MS Cache",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 2400, Description = "Cisco-PIX MD5", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 2410, Description = "Cisco-ASA MD5", IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 2500, Description = "WPA/WPA2", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 2501, Description = "WPA-EAPOL-PMK", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 2600, Description = "md5(md5($pass))", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 2611, Description = "vBulletin < v3.8.5", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 2612, Description = "PHPS", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 2711, Description = "vBulletin >= v3.8.5", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 2811, Description = "IPB2+, MyBB1.2+", IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 3000, Description = "LM", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 3100, Description = "Oracle H: Type (Oracle 7+}, DES(Oracle)",
                IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3200, Description = "bcrypt, Blowfish(OpenBSD)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3500, Description = "md5(md5(md5($pass)))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3710, Description = "md5($salt.md5($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3711, Description = "Mediawiki B type", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3800, Description = "md5($salt.$pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 3910, Description = "md5(md5($pass).md5($salt))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4010, Description = "md5($salt.md5($salt.$pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4110, Description = "md5($salt.md5($pass.$salt))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4300, Description = "md5(strtoupper(md5($pass)))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4400, Description = "md5(sha1($pass))", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4410, Description = "md5(sha1($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4500, Description = "sha1(sha1($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4510, Description = "sha1(sha1($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4520, Description = "sha1($salt.sha1($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4521, Description = "Redmine Project Management Web App", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 4522, Description = "PunBB", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 4700, Description = "sha1(md5($pass))", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4710, Description = "sha1(md5($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4711, Description = "Huawei sha1(md5($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4800, Description = "MD5(Chap}, iSCSI CHAP authentication",
                IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 4900, Description = "sha1($salt.$pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 5000, Description = "SHA-3(Keccak)", IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 5100, Description = "Half MD5", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 5200, Description = "Password Safe v3", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 5300, Description = "IKE-PSK MD5", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 5400, Description = "IKE-PSK SHA1", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 5500, Description = "NetNTLMv1-VANILLA / NetNTLMv1+ESS", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 5600, Description = "NetNTLMv2", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 5700, Description = "Cisco-IOS SHA256", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 5800, Description = "Samsung Android Password/PIN", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 6000, Description = "RipeMD160", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 6100, Description = "Whirlpool", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 6211,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES/Serpent/Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6212,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES-Twofish/Serpent-AES/Twofish-Serpent",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6213,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES-Twofish-Serpent/Serpent-Twofish-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6221, Description = "TrueCrypt 5.0+ SHA512 + AES/Serpent/Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6222,
                Description = "TrueCrypt 5.0+ SHA512 + AES-Twofish/Serpent-AES/Twofish-Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6223,
                Description = "TrueCrypt 5.0+ SHA512 + AES-Twofish-Serpent/Serpent-Twofish-AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6231, Description = "TrueCrypt 5.0+ Whirlpool + AES/Serpent/Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6232,
                Description = "TrueCrypt 5.0+ Whirlpool + AES-Twofish/Serpent-AES/Twofish-Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6233,
                Description = "TrueCrypt 5.0+ Whirlpool + AES-Twofish-Serpent/Serpent-Twofish-AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6241,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES/Serpent/Twofish + boot", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6242,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES-Twofish/Serpent-AES/Twofish-Serpent + boot",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6243,
                Description = "TrueCrypt 5.0+ PBKDF2-HMAC-RipeMD160 + AES-Twofish-Serpent/Serpent-Twofish-AES + boot",
                IsSalted = false, IsSlowHash = true
            },
            new HashType { HashcatId = 6300, Description = "AIX {smd5}", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 6400, Description = "AIX {ssha256}", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6500, Description = "AIX {ssha512}", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 6600, Description = "1Password, Agile Keychain", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 6700, Description = "AIX {ssha1}", IsSalted = false, IsSlowHash = true },
            new HashType { HashcatId = 6800, Description = "Lastpass", IsSalted = true, IsSlowHash = true },
            new HashType
            {
                HashcatId = 6900, Description = "GOST R 34.11-94", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7000, Description = "Fortigate (FortiOS)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7100, Description = "OS X v10.8 / v10.9", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 7200, Description = "GRUB 2", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 7300, Description = "IPMI2 RAKP HMAC-SHA1", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7400, Description = "sha256crypt, SHA256(Unix)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7401, Description = "MySQL $A$ (sha256crypt)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7500, Description = "Kerberos 5 AS-REQ Pre-Auth", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7700, Description = "SAP CODVN B (BCODE)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7701, Description = "SAP CODVN B (BCODE) from RFC_READ_TABLE",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7800, Description = "SAP CODVN F/G (PASSCODE)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 7801, Description = "SAP CODVN F/G (PASSCODE) from RFC_READ_TABLE",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 7900, Description = "Drupal7", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 8000, Description = "Sybase ASE", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 8100, Description = "Citrix Netscaler", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 8200, Description = "1Password, Cloud Keychain", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 8300, Description = "DNSSEC (NSEC3)", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 8400, Description = "WBB3, Woltlab Burning Board 3", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 8500, Description = "RACF", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 8600, Description = "Lotus Notes/Domino 5", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 8700, Description = "Lotus Notes/Domino 6", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 8800, Description = "Android FDE <= 4.3", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 8900, Description = "scrypt", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 9000, Description = "Password Safe v2", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9100, Description = "Lotus Notes/Domino", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 9200, Description = "Cisco $8$", IsSalted = false, IsSlowHash = true },
            new HashType { HashcatId = 9300, Description = "Cisco $9$", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 9400, Description = "Office 2007", IsSalted = false, IsSlowHash = true },
            new HashType { HashcatId = 9500, Description = "Office 2010", IsSalted = false, IsSlowHash = true },
            new HashType { HashcatId = 9600, Description = "Office 2013", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 9700, Description = "MS Office ⇐ 2003 MD5 + RC4, oldoffice$0, oldoffice$1",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9710, Description = "MS Office <= 2003 $0/$1, MD5 + RC4, collider #1",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9720, Description = "MS Office <= 2003 $0/$1, MD5 + RC4, collider #2",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9800, Description = "MS Office ⇐ 2003 SHA1 + RC4, oldoffice$3, oldoffice$4",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9810, Description = "MS Office <= 2003 $3, SHA1 + RC4, collider #1",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 9820, Description = "MS Office <= 2003 $3, SHA1 + RC4, collider #2",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 9900, Description = "Radmin2", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 10000, Description = "Django (PBKDF2-SHA256)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 10100, Description = "SipHash", IsSalted = true, IsSlowHash = false },
            new HashType { HashcatId = 10200, Description = "Cram MD5", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 10300, Description = "SAP CODVN H (PWDSALTEDHASH) iSSHA-1",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10400, Description = "PDF 1.1 - 1.3 (Acrobat 2 - 4)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10410, Description = "PDF 1.1 - 1.3 (Acrobat 2 - 4}, collider #1",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10420, Description = "PDF 1.1 - 1.3 (Acrobat 2 - 4}, collider #2",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10500, Description = "PDF 1.4 - 1.6 (Acrobat 5 - 8)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10600, Description = "PDF 1.7 Level 3 (Acrobat 9)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10700, Description = "PDF 1.7 Level 8 (Acrobat 10 - 11)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 10800, Description = "SHA384", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 10810, Description = "sha384($pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10820, Description = "sha384($salt.$pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10830, Description = "sha384(utf16le($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10840, Description = "sha384($salt.utf16le($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10870, Description = "sha384(utf16le($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 10900, Description = "PBKDF2-HMAC-SHA256", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 10901, Description = "RedHat 389-DS LDAP (PBKDF2-HMAC-SHA256)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType { HashcatId = 11000, Description = "PrestaShop", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 11100, Description = "PostgreSQL Challenge-Response Authentication (MD5)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11200, Description = "MySQL Challenge-Response Authentication (SHA1)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11300, Description = "Bitcoin/Litecoin wallet.dat", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 11400, Description = "SIP digest authentication (MD5)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 11500, Description = "CRC32", IsSalted = true, IsSlowHash = false },
            new HashType { HashcatId = 11600, Description = "7-Zip", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 11700, Description = "GOST R 34.11-2012 (Streebog) 256-bit",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11750, Description = "HMAC-Streebog-256 (key = $pass}, big-endian",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11760, Description = "HMAC-Streebog-256 (key = $salt}, big-endian",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11800, Description = "GOST R 34.11-2012 (Streebog) 512-bit",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11850, Description = "HMAC-Streebog-512 (key = $pass}, big-endian",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11860, Description = "HMAC-Streebog-512 (key = $salt}, big-endian",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 11900, Description = "PBKDF2-HMAC-MD5", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12000, Description = "PBKDF2-HMAC-SHA1", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12001, Description = "Atlassian (PBKDF2-HMAC-SHA1)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12100, Description = "PBKDF2-HMAC-SHA512", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 12200, Description = "eCryptfs", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 12300, Description = "Oracle T: Type (Oracle 12+)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12400, Description = "BSDiCrypt, Extended DES", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 12500, Description = "RAR3-hp", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 12600, Description = "ColdFusion 10+", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 12700, Description = "Blockchain, My Wallet", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12800, Description = "MS-AzureSync PBKDF2-HMAC-SHA256", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 12900, Description = "Android FDE (Samsung DEK)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 13000, Description = "RAR5", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 13100, Description = "Kerberos 5 TGS-REP etype 23", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 13200, Description = "AxCrypt", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 13300, Description = "AxCrypt in memory SHA1", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 13400, Description = "Keepass 1/2 AES/Twofish with/without keyfile",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 13500, Description = "PeopleSoft PS_TOKEN", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 13600, Description = "WinZip", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 13711,
                Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + AES, Serpent, Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13712,
                Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + AES-Twofish, Serpent-AES, Twofish-Serpent",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13713,
                Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + Serpent-Twofish-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13721, Description = "VeraCrypt PBKDF2-HMAC-SHA512 + AES, Serpent, Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13722,
                Description = "VeraCrypt PBKDF2-HMAC-SHA512 + AES-Twofish, Serpent-AES, Twofish-Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13723, Description = "VeraCrypt PBKDF2-HMAC-SHA512 + Serpent-Twofish-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13731,
                Description = "VeraCrypt PBKDF2-HMAC-Whirlpool + AES, Serpent, Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13732,
                Description = "VeraCrypt PBKDF2-HMAC-Whirlpool + AES-Twofish, Serpent-AES, Twofish-Serpent",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13733,
                Description = "VeraCrypt PBKDF2-HMAC-Whirlpool + Serpent-Twofish-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13741, Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + boot-mode + AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13742,
                Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + boot-mode + AES-Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13743,
                Description = "VeraCrypt PBKDF2-HMAC-RIPEMD160 + boot-mode + AES-Twofish-Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13751, Description = "VeraCrypt PBKDF2-HMAC-SHA256 + AES, Serpent, Twofish",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13752,
                Description = "VeraCrypt PBKDF2-HMAC-SHA256 + AES-Twofish, Serpent-AES, Twofish-Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13753, Description = "VeraCrypt PBKDF2-HMAC-SHA256 + Serpent-Twofish-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13761,
                Description = "VeraCrypt PBKDF2-HMAC-SHA256 + boot-mode (PIM + AES | Twofish)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13762,
                Description = "VeraCrypt PBKDF2-HMAC-SHA256 + boot-mode + Serpent-AES",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13763,
                Description = "VeraCrypt PBKDF2-HMAC-SHA256 + boot-mode + Serpent-Twofish-AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13771, Description = "VeraCrypt Streebog-512 + XTS 512 bit",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13772, Description = "VeraCrypt Streebog-512 + XTS 1024 bit",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13773, Description = "VeraCrypt Streebog-512 + XTS 1536 bit",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13781,
                Description = "VeraCrypt Streebog-512 + XTS 512 bit + boot-mode (legacy)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13782,
                Description = "VeraCrypt Streebog-512 + XTS 1024 bit + boot-mode (legacy)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13783,
                Description = "VeraCrypt Streebog-512 + XTS 1536 bit + boot-mode (legacy)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 13800, Description = "Windows 8+ phone PIN/Password", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 13900, Description = "OpenCart", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 14000, Description = "DES (PT = $salt, key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 14100, Description = "3DES (PT = $salt, key = $pass)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType { HashcatId = 14400, Description = "sha1(CX)", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 14500, Description = "Linux Kernel Crypto API (2.4)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 14600, Description = "LUKS 10", IsSalted = false, IsSlowHash = true },
            new HashType
            {
                HashcatId = 14700, Description = "iTunes Backup < 10.0 11", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 14800, Description = "iTunes Backup >= 10.0 11", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 14900, Description = "Skip32 12", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 15000, Description = "FileZilla Server >= 0.9.55", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 15100, Description = "Juniper/NetBSD sha1crypt", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 15200, Description = "Blockchain, My Wallet, V2", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 15300, Description = "DPAPI masterkey file v1 and v2", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 15310, Description = "DPAPI masterkey file v1 (context 3)",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 15400, Description = "ChaCha20", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 15500, Description = "JKS Java Key Store Private Keys (SHA1)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 15600, Description = "Ethereum Wallet, PBKDF2-HMAC-SHA256",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 15700, Description = "Ethereum Wallet, SCRYPT", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 15900,
                Description = "DPAPI master key file version 2 + Active Directory domain context", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 15910, Description = "DPAPI masterkey file v2 (context 3)",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 16000, Description = "Tripcode", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 16100, Description = "TACACS+", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 16200, Description = "Apple Secure Notes", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 16300, Description = "Ethereum Pre-Sale Wallet, PBKDF2-HMAC-SHA256",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 16400, Description = "CRAM-MD5 Dovecot", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 16500, Description = "JWT (JSON Web Token)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 16600, Description = "Electrum Wallet (Salt-Type 1-3)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 16700, Description = "FileVault 2", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 16800, Description = "WPA-PMKID-PBKDF2", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 16801, Description = "WPA-PMKID-PMK", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 16900, Description = "Ansible Vault", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 17010, Description = "GPG (AES-128/AES-256 (SHA-1($pass)))",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 17200, Description = "PKZIP (Compressed)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17210, Description = "PKZIP (Uncompressed)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17220, Description = "PKZIP (Compressed Multi-File)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17225, Description = "PKZIP (Mixed Multi-File)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17230, Description = "PKZIP (Compressed Multi-File Checksum-Only)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 17300, Description = "SHA3-224", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 17400, Description = "SHA3-256", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 17500, Description = "SHA3-384", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 17600, Description = "SHA3-512", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 17700, Description = "Keccak-224", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17800, Description = "Keccak-256", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 17900, Description = "Keccak-384", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 18000, Description = "Keccak-512", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 18100, Description = "TOTP (HMAC-SHA1)", IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 18200, Description = "Kerberos 5 AS-REP etype 23", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18300, Description = "Apple File System (APFS)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18400, Description = "Open Document Format (ODF) 1.2 (SHA-256, AES)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18500, Description = "sha1(md5(md5($pass)))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 18600, Description = "Open Document Format (ODF) 1.1 (SHA-1, Blowfish)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18700, Description = "Java Object hashCode()", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18800, Description = "Blockchain, My Wallet, Second Password (SHA256)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 18900, Description = "Android Backup", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19000, Description = "QNX /etc/shadow (MD5)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19100, Description = "QNX /etc/shadow (SHA256)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19200, Description = "QNX /etc/shadow (SHA512)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19300, Description = "sha1($salt1.$pass.$salt2)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 19500, Description = "Ruby on Rails Restful-Authentication",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 19600,
                Description = "Kerberos 5 TGS-REP etype 17 (AES128-CTS-HMAC-SHA1-96)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19700,
                Description = "Kerberos 5 TGS-REP etype 18 (AES256-CTS-HMAC-SHA1-96)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19800, Description = "Kerberos 5, etype 17, Pre-Auth", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 19900, Description = "Kerberos 5, etype 18, Pre-Auth", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20011,
                Description
                    = "DiskCryptor SHA512 + XTS 512 bit (AES) / DiskCryptor SHA512 + XTS 512 bit (Twofish) / DiskCryptor SHA512 + XTS 512 bit (Serpent)",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20012,
                Description
                    = "DiskCryptor SHA512 + XTS 1024 bit (AES-Twofish) / DiskCryptor SHA512 + XTS 1024 bit (Twofish-Serpent) / DiskCryptor SHA512 + XTS 1024 bit (Serpent-AES)",
                IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20013,
                Description = "DiskCryptor SHA512 + XTS 1536 bit (AES-Twofish-Serpent)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20200, Description = "Python passlib pbkdf2-sha512", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20300, Description = "Python passlib pbkdf2-sha256", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 20400, Description = "Python passlib pbkdf2-sha1", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20500, Description = "PKZIP Master Key", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20510, Description = "PKZIP Master Key (6 byte optimization)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20600, Description = "Oracle Transportation Management (SHA256)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20710, Description = "sha256(sha256($pass).$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20711, Description = "AuthMe sha256", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20720, Description = "sha256($salt.sha256($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20800, Description = "sha256(md5($pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 20900, Description = "md5(sha1($pass).md5($pass).sha1($pass))",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21000, Description = "BitShares v0.x - sha512(sha512_bin(pass))",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21100, Description = "sha1(md5($pass.$salt))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21200, Description = "md5(sha1($salt).md5($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21300, Description = "md5($salt.sha1($salt.$pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21400, Description = "sha256(sha256_bin(pass))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21420, Description = "sha256($salt.sha256_bin($pass))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21500, Description = "SolarWinds Orion", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21501, Description = "SolarWinds Orion v2", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21600, Description = "Web2py pbkdf2-sha512", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21700, Description = "Electrum Wallet (Salt-Type 4)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 21800, Description = "Electrum Wallet (Salt-Type 5)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22000, Description = "WPA-PBKDF2-PMKID+EAPOL", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22001, Description = "WPA-PMK-PMKID+EAPOL", IsSalted = false,
                IsSlowHash = false
            },
            new HashType { HashcatId = 22100, Description = "BitLocker", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 22200, Description = "Citrix NetScaler (SHA512)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22300, Description = "sha256($salt.$pass.$salt)", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22301, Description = "Telegram client app passcode (SHA256)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22400, Description = "AES Crypt (SHA256)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22500, Description = "MultiBit Classic .key (MD5)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22600, Description = "Telegram Desktop App Passcode (PBKDF2-HMAC-SHA1)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22700, Description = "MultiBit HD (scrypt)", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 22911, Description = "RSA/DSA/EC/OPENSSH Private Keys ($0$)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22921, Description = "RSA/DSA/EC/OPENSSH Private Keys ($6$)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22931, Description = "RSA/DSA/EC/OPENSSH Private Keys ($1, $3$)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22941, Description = "RSA/DSA/EC/OPENSSH Private Keys ($4$)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 22951, Description = "RSA/DSA/EC/OPENSSH Private Keys ($5$)",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23001, Description = "SecureZIP AES-128", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23002, Description = "SecureZIP AES-192", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23003, Description = "SecureZIP AES-256", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23100, Description = "Apple Keychain", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 23200, Description = "XMPP SCRAM PBKDF2-SHA1", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23300, Description = "Apple iWork", IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 23400, Description = "Bitwarden", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 23500, Description = "AxCrypt 2 AES-128", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23600, Description = "AxCrypt 2 AES-256", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23700, Description = "RAR3-p (Uncompressed)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23800, Description = "RAR3-p (Compressed)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 23900, Description = "BestCrypt v3 Volume Encryption", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24100, Description = "MongoDB ServerKey SCRAM-SHA-1", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24200, Description = "MongoDB ServerKey SCRAM-SHA-256", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24300, Description = "sha1($salt.sha1($pass.$salt))", IsSalted = true,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24410, Description = "PKCS#8 Private Keys (PBKDF2-HMAC-SHA1 + 3DES/AES)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24420, Description = "PKCS#8 Private Keys (PBKDF2-HMAC-SHA256 + 3DES/AES)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24500, Description = "Telegram Desktop >= v2.1.14 (PBKDF2-HMAC-SHA512)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 24600, Description = "SQLCipher", IsSalted = false, IsSlowHash = false },
            new HashType { HashcatId = 24700, Description = "Stuffit5", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 24800, Description = "Umbraco HMAC-SHA1", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 24900, Description = "Dahua Authentication MD5", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 25000, Description = "SNMPv3 HMAC-MD5-96/HMAC-SHA1-96", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 25100, Description = "SNMPv3 HMAC-MD5-96", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 25200, Description = "SNMPv3 HMAC-SHA1-96", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 25300, Description = "MS Office 2016 - SheetProtection", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 25400, Description = "PDF 1.4 - 1.6 (Acrobat 5 - 8) - edit password",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 25500, Description = "Stargazer Stellar Wallet XLM", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 25600, Description = "bcrypt(md5($pass)) / bcryptmd5", IsSalted = false,
                IsSlowHash = true
            },
            new HashType { HashcatId = 25700, Description = "MurmurHash", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 25800, Description = "bcrypt(sha1($pass)) / bcryptsha1", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 25900, Description = "KNX IP Secure - Device Authentication Code",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26000, Description = "Mozilla key3.db", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26100, Description = "Mozilla key4.db", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26200, Description = "OpenEdge Progress Encode", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26300, Description = "FortiGate256 (FortiOS256)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26401, Description = "AES-128-ECB NOKDF (PT = $salt, key = $pass)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26402, Description = "AES-192-ECB NOKDF (PT = $salt, key = $pass)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26403, Description = "AES-256-ECB NOKDF (PT = $salt, key = $pass)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26500, Description = "iPhone passcode (UID key + System Keybag)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26600, Description = "MetaMask Wallet", IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 26700, Description = "SNMPv3 HMAC-SHA224-128", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26800, Description = "SNMPv3 HMAC-SHA256-192", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 26900, Description = "SNMPv3 HMAC-SHA384-256", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27000, Description = "NetNTLMv1 / NetNTLMv1+ESS (NT)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27100, Description = "NetNTLMv2 (NT)", IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27200, Description = "Ruby on Rails Restful Auth (one round, no sitekey)",
                IsSalted = true, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27300, Description = "SNMPv3 HMAC-SHA512-384", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27400, Description = "VMware VMX (PBKDF2-HMAC-SHA1 + AES-256-CBC)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27500, Description = "VirtualBox (PBKDF2-HMAC-SHA256 & AES-128-XTS)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 27600, Description = "VirtualBox (PBKDF2-HMAC-SHA256 & AES-256-XTS)",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 27700, Description = "MultiBit Classic .wallet (scrypt)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 27800, Description = "MurmurHash3", IsSalted = true, IsSlowHash = false
            },
            new HashType { HashcatId = 27900, Description = "CRC32C", IsSalted = true, IsSlowHash = false },
            new HashType { HashcatId = 28000, Description = "CRC64Jones", IsSalted = true, IsSlowHash = false },
            new HashType
            {
                HashcatId = 28100, Description = "Windows Hello PIN/Password", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 28200, Description = "Exodus Desktop Wallet (scrypt)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28300, Description = "Teamspeak 3 (channel hash)", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28400, Description = "bcrypt(sha512($pass)) / bcryptsha512",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28501, Description = "Bitcoin WIF private key (P2PKH}, compressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28502, Description = "Bitcoin WIF private key (P2PKH}, uncompressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28503,
                Description = "Bitcoin WIF private key (P2WPKH, Bech32}, compressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28504,
                Description = "Bitcoin WIF private key (P2WPKH, Bech32}, uncompressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28505, Description = "Bitcoin WIF private key (P2SH(P2WPKH)}, compressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28506,
                Description = "Bitcoin WIF private key (P2SH(P2WPKH)}, uncompressed",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28600, Description = "PostgreSQL SCRAM-SHA-256", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 28700, Description = "Amazon AWS4-HMAC-SHA256", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 28800, Description = "Kerberos 5, etype 17, DB", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 28900, Description = "Kerberos 5, etype 18, DB", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29000,
                Description = "sha1($salt.sha1(utf16le($username).\":\".utf16le($pass)))", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29100, Description = "Flask Session Cookie ($salt.$salt.$pass)",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 29200, Description = "Radmin3", IsSalted = false, IsSlowHash = false },
            new HashType
            {
                HashcatId = 29311, Description = "TrueCrypt RIPEMD160 + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29312, Description = "TrueCrypt RIPEMD160 + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29313, Description = "TrueCrypt RIPEMD160 + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29321, Description = "TrueCrypt SHA512 + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29322, Description = "TrueCrypt SHA512 + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29323, Description = "TrueCrypt SHA512 + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29331, Description = "TrueCrypt Whirlpool + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29332, Description = "TrueCrypt Whirlpool + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29333, Description = "TrueCrypt Whirlpool + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29341, Description = "TrueCrypt RIPEMD160 + XTS 512 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29342, Description = "TrueCrypt RIPEMD160 + XTS 1024 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29343, Description = "TrueCrypt RIPEMD160 + XTS 1536 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29411, Description = "VeraCrypt RIPEMD160 + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29412, Description = "VeraCrypt RIPEMD160 + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29413, Description = "VeraCrypt RIPEMD160 + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29421, Description = "VeraCrypt SHA512 + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29422, Description = "VeraCrypt SHA512 + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29423, Description = "VeraCrypt SHA512 + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29431, Description = "VeraCrypt Whirlpool + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29432, Description = "VeraCrypt Whirlpool + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29433, Description = "VeraCrypt Whirlpool + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29441, Description = "VeraCrypt RIPEMD160 + XTS 512 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29442, Description = "VeraCrypt RIPEMD160 + XTS 1024 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29443, Description = "VeraCrypt RIPEMD160 + XTS 1536 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29451, Description = "VeraCrypt SHA256 + XTS 512 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29452, Description = "VeraCrypt SHA256 + XTS 1024 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29453, Description = "VeraCrypt SHA256 + XTS 1536 bit", IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29461, Description = "VeraCrypt SHA256 + XTS 512 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29462, Description = "VeraCrypt SHA256 + XTS 1024 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29463, Description = "VeraCrypt SHA256 + XTS 1536 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29471, Description = "VeraCrypt Streebog-512 + XTS 512 bit",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29472, Description = "VeraCrypt Streebog-512 + XTS 1024 bit",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29473, Description = "VeraCrypt Streebog-512 + XTS 1536 bit",
                IsSalted = false,
                IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29481, Description = "VeraCrypt Streebog-512 + XTS 512 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29482, Description = "VeraCrypt Streebog-512 + XTS 1024 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29483, Description = "VeraCrypt Streebog-512 + XTS 1536 bit + boot-mode",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 29511, Description = "LUKS v1 SHA-1 + AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29512, Description = "LUKS v1 SHA-1 + Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29513, Description = "LUKS v1 SHA-1 + Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29521, Description = "LUKS v1 SHA-256 + AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29522, Description = "LUKS v1 SHA-256 + Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29523, Description = "LUKS v1 SHA-256 + Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29531, Description = "LUKS v1 SHA-512 + AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29532, Description = "LUKS v1 SHA-512 + Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29533, Description = "LUKS v1 SHA-512 + Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29541, Description = "LUKS v1 RIPEMD-160 + AES", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29542, Description = "LUKS v1 RIPEMD-160 + Serpent", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29543, Description = "LUKS v1 RIPEMD-160 + Twofish", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29600, Description = "Terra Station Wallet (AES256-CBC(PBKDF2($pass)))",
                IsSalted = false, IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 29700,
                Description = "KeePass 1 (AES/Twofish) and KeePass 2 (AES) - keyfile only mode", IsSalted = false,
                IsSlowHash = true
            },
            new HashType
            {
                HashcatId = 30000, Description = "Python Werkzeug MD5 (HMAC-MD5 (key = $salt))",
                IsSalted = false, IsSlowHash = false
            },
            new HashType
            {
                HashcatId = 30120, Description = "Python Werkzeug SHA256 (HMAC-SHA256 (key = $salt))",
                IsSalted = false, IsSlowHash = false
            },
            new HashType { HashcatId = 99999, Description = "Plaintext", IsSalted = false, IsSlowHash = false }
        };
    }
}
