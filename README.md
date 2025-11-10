Aplikacja internetowa stworzona w technologii **ASP.NET Core** do sprzedaży etui na telefony.  
Projekt prezentuje wykorzystanie **Entity Framework Core**, **Identity** oraz integrację z systemem płatności **Stripe**.  
Zawiera część użytkownika (frontend sklepu) oraz **panel administracyjny** do zarządzania produktami.

##  Funkcjonalności

-  **Strona główna** – prezentacja wybranych produktów  
-  **Lista produktów** – przeglądanie oferty sklepu  
-  **Koszyk / mini-koszyk** – dodawanie, edycja i usuwanie produktów  
-  **Płatności Stripe** – bezpieczna płatność online  
-  **Logowanie Google** – autoryzacja użytkowników przez Google OAuth  
-  **Panel administracyjny** – dodawanie i edycja produktów, zarządzanie ofertą  
-  **Podsumowanie zamówienia** – finalizacja zakupów i historia transakcji  
-  **Baza danych SQL** – zarządzana przez Entity Framework Core  


##  Wykorzystane technologie

| Warstwa | Technologie |
|----------|--------------|
| **Backend** | ASP.NET Core MVC, C#, Entity Framework Core |
| **Baza danych** | SQL Server |
| **Uwierzytelnianie** | ASP.NET Identity, Google OAuth, JWT |
| **Płatności** | Stripe API |
| **Frontend** | Razor Pages, HTML, CSS, Bootstrap |
| **Kontrola wersji** | Git / GitHub |


##  Uruchomienie projektu lokalnie

### 1️ Sklonuj repozytorium
```bash
git clone https://github.com/M-Mencel/E-Shop.git
cd E-Shop

```

### 2 Skonfiguruj połączenie z bazą danych

W pliku appsettings.json uzupełnij połączenie do swojego serwera SQL:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EshopDB;Trusted_Connection=True;"
}
```
### 3 Wykonaj migracje bazy danych
```bash
dotnet ef database update
```

### 4 Uruchom aplikacje
```bash
dotnet run
```

###  Konfiguracja kluczy API

Aby korzystać z funkcji logowania przez Google oraz płatności Stripe,  
należy utworzyć własne klucze API i dodać je do pliku `appsettings.json` lub do zmiennych środowiskowych.

#### Google OAuth
W pliku `appsettings.json` w sekcji `Authentication:Google` uzupełnij swoje dane:
```json
"Authentication": {
  "Google": {
    "ClientId": "YOUR_GOOGLE_CLIENT_ID",
    "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
  }
}

```
Uwaga: Klucze API zostały usunięte z repozytorium ze względów bezpieczeństwa.
Aby uruchomić projekt, należy wprowadzić własne dane uwierzytelniające z panelu Google Cloud Console

###  Plik konfiguracyjny `appsettings.Development.json`

W repozytorium znajduje się przykładowy plik `appsettings.Development.json` zawierający jedynie strukturę konfiguracji.  
Wszystkie dane wrażliwe (np. klucze API, dane logowania, connection stringi) zostały celowo usunięte.  
Plik może posłużyć jako wzór do własnej konfiguracji lokalnej podczas uruchamiania projektu.

>  W przypadku uruchomienia projektu należy uzupełnić brakujące wartości lub utworzyć własny plik konfiguracyjny z odpowiednimi kluczami.


## Cele projektu
Projekt został stworzony w celu:
- doskonalenia pracy z **Entity Framework Core** i **LINQ**,  
- poznania integracji z zewnętrznymi usługami (**Stripe**, **Google Auth**),  
- ćwiczenia implementacji **autoryzacji i uwierzytelniania** w ASP.NET Core,  
- utrwalenia umiejętności projektowania **pełnej aplikacji webowej** (backend + frontend).
