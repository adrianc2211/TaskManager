# TaskManager
Aplikacja do zarządzania zadaniami w firmie

Aby uruchomić aplikację niezbędne będzie posiadanie:

- Visual Studio 2022
- SQL SERVER

Następnie trzeba ustawić odpowiednie ConnectionString’i w pliku appsettings.json.

Wykonanie polecenia upadate-database zaktualizuje odpowiednio bazę danych bez tego aplikacja nie będzie działać prawidłowo.

Aplikacja jest w wykonana w wersji .Net 6.

Opis funkcji aplikacji
Po włączeniu aplikacji na pierwszym planie pojawi się formularz logowania. W górnej belce są dostępne 3 przyciski: Menadżer zadań, Rejestracja oraz Logowanie. Po zalogowaniu się na odpowiednie konto z uprawnieniami (Email: admin@wp.pl, Hasło: Hasło123#@!) będą dostępne inne akcję:

- Wyloguj
- Dodaj użytkownika -> tutaj zobaczymy formularz który odpowiada za dodanie użytkownika. Niżej również zobaczymy listę wszystkich użytkowników w aplikacji. Możemy również wykonać na nich akcję Usuń
- Dodaj zadanie -> formularz oraz lista zadań, które możemy rozbudować o dodatkowy opis szczegółowy. Również jest opcja Usuń.
- Dodaj zadanie użytkownikowi -> na podstawie identyfikatora możemy przypisać konkretne zadanie do użytkownika. Jest również lista.

W aplikacji są dwa rodzaje uprawnień:

- normal -> posiada okrojoną wersję aplikacji
- admin -> posiada dostęp do wszystkich funkcjonalności

 
