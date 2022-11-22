#Basic instructions

Wszystkie funkcjonalności określone w wymaganiach projektu są dostępne przy użyciu kolejnych kontrolek widocznych w interfejsie użytkownika:
 - Import - import pliku z rozszerzeniem .obj o konkretnie określonej strukturze (zaleca się używanie załączonych pod domyślnym adresem wyboru pliku, przykładowych modeli (.obj)
 - Load Texture - import tekstury, kolory której mają być używane do kolorowania pixeli w miejsce stałego koloru obiektu ustawianego suwakami (.jpg, .png)
 - Load Normal Map - import mapy normalnej używanej do modyfikacji wektora normalnego oświetlanego obiektu (.jpg, .png)
 - Start Animation - program rozpoczyna zapętloną animację poruszania źródłem światła po torze spirali na płaszczyźnie równoległej do ekranu (x, y), dla zadanej suwakiem współrzędnej z, nie zaleca się zmieniania rozmiaru okna podczas trwania animacji, można poruszać suwakami zmianiając parametry wyświetlania, natomiast wszelkie importowanie jest zablokowane
 - Stop Animation - aktywna animacja zatrzymuje się
 - Options - toggle Mesh uwidacznia siatkę krawędzi modelu reprezentowanego przez wczytany model (.obj), toggle Normal Vectors Map włącza modyfikację wektorów normalnych wczytanego modelu przy użyciu wczytanej mapy wektorów normalnych
 - Object Color Control - wybór pomiędzy pobieraniem koloru, którym wypełniany jest zaimportowany model pomiędzy ustalonym suwakami kolorem obiektu i, a pobieraniem ich z wczytanej tekstury
 - Interpolation Method - wybór pomiędzy sposobem interpolacji - interpolacja wektorów (Vectors) lub interpolacja kolorów (Colors)
 - Suwaki po prawej stronie modyfikują parametry obliczeniowe zaimplementowanego modelu -  kolejno: Kd, Ks, m (stałe z równania modelu oświetlenia), Light X/Y/Z (położenie światła względem modelu (z jest współrzędną wgłąb) w zakresie X,Y - 3 wysokości obiektu, Z - 1.5 wysokości obiektu począwszy od jego 'najwyższego' punktu), Light R/G/B suwaki określające kolor światła za pomocą współrzędnych RGB (0 - 255), Object R/G/B suwaki określające kolor obiektu za pomocą współrzędnych RGB (0 - 255)

#Known issues

- Podczas importu obiektu, podczas wykonywania algorytmu wypełniania obiektu czasami rzucany jest NullReferenceException, co jest prawdopodobnie związane z różniącymi się marginalnymi szczegółami i zaokrągleniami importowanych plików .obj