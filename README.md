# UI_RPG
Sagatavoja: Signe Zalužinska
Šis ir vispārējs paskaidrojums par to, kas tika pievienots spēlei.

// Spēle ir RPG kas darbojas caur UI slāni. Uz ekrāna ir redzmas spēlētāja un pretinieka statistikas. Spēlētajam ir iespēja uzbrukt un ieslēgt vai izslēgt vairogu. Vairogs samazina saņemto sitienu spēku, taču pastāv varbūtība, ka tas tiks iznīcināts. Pēc spēlētāja uzbrukuma pretinieks automātiski uzbrūk spēlētājam. // 

Tika papildināts player.cs - tas atbild par attack, buff, shield un heal pogu funkcionalitāti. Tāpat tas atbild arī par ienaidnieku maiņu, damage funkciju, win un lose ekrānu trigerēšanu un pārējo UI elementu izslēgšanu. 
Shield aizsargā nedaudz un pastāv 50% iespējamība, ka tas tiks iznīcināts ar nākamo sitienu.

izveidots GameTimer.cs, kurš ļauj uzlikt taimeri spēlei.
Papildināts UI, win un lose screen 

MANTOŠANA
No Character mantojas Player klase un Enemy klase.
Berseker mantojas no Enemy
No weapon mantojas PoisonWeapon un BasicWeapon

ENKAPSULĀCIJA
Character.cs ir getter setter

ABSTRAKCIJA
Weapon izriet no MonoBehaviour un tā ir abstrakta klase. No tās manto BasicWeapon.cs un PoisonWeapon.cs

POLIMORFISMS 
PoisonWeapon.cs ir funkcija ApplyEffect, kuru izmanto override

PAPILDUS UZDEVUMS
Tika pievienots damage buff, kas dod 3x spēcīgāku sitienu un healing poga, kas iedod +20 dzīvības punktus. Pievienoju zvanu skaņu efektu spēles sākumā on awake.
