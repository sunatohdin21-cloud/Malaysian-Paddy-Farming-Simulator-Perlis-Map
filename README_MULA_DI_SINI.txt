EXITA UTARA FARMING SIMULATOR — UNITY FOUNDATION
================================================

PENTING:
Ini ialah asas projek Unity, BUKAN game siap dan BUKAN APK siap.
Belum ada model 3D sebenar untuk traktor, combine, lori, implement atau map.
Fail ini sengaja tidak menggunakan bentuk kotak sebagai model jentera.

KANDUNGAN ASAS
- Struktur projek Unity 2022.3 LTS
- Pengawal kenderaan asas menggunakan Rigidbody
- Bunyi enjin/ekzos yang berubah mengikut RPM (perlu fail audio sebenar)
- Sistem titik sambungan peralatan sawah
- Tetapan build Android melalui GitHub Actions

SPESIFIKASI YANG DIKUNCI
1. Traktor Ford, Mercedes-Benz dan Mitsubishi:
   dua tayar getah di depan, dua track/rantai besi di belakang.
2. New Holland 1454 dan 8080:
   track/rantai besi di depan, tayar getah di belakang.
3. Lori: Hino 500 tipper.
4. Peralatan: bajak, rotavator, perata tanah, penanam padi,
   penyembur baja/racun dan peralatan menuai.
5. Map: Pokok Jawi, kawasan Batu Pahat, Perlis.
6. Bunyi diesel turbo/ekzos kasar mengikut RPM.

CARA GUNA MELALUI TELEFON
1. Extract ZIP ini.
2. Upload kandungan folder EXITA_UTARA_UNITY_FOUNDATION ke repository GitHub
   EXITA-UTARA-FARMING-SIMULATOR.
3. GitHub Actions belum boleh menghasilkan APK sehingga projek Unity lengkap
   dengan scene, aset 3D/audio dan Unity license yang sah.
4. Jangan masukkan fail rahsia/lesen ke repository awam.

KEPERLUAN UNTUK BUILD UNITY DI GITHUB
Tambahkan GitHub Actions secrets yang diperlukan oleh GameCI:
- UNITY_LICENSE
- UNITY_EMAIL
- UNITY_PASSWORD

Nota: penggunaan lesen Unity dan syarat akaun bergantung pada jenis lesen Unity.
Workflow disediakan sebagai rangka, bukan jaminan build akan berjaya sekarang.

LANGKAH PEMBANGUNAN SETERUSNYA
- Tambah model 3D sebenar dan rig kenderaan.
- Bina scene map dan terrain.
- Tambah audio diesel sebenar atau audio berlesen.
- Tambah sistem kerja sawah dan UI sentuh.
- Uji prestasi pada Redmi A5 sebelum keluarkan APK.
