# teldat-recruitment-exercise

# Opis zadania: 
Zadanie polega na napisaniu aplikacji pt. "Todo List"
## Założenia: 

* aplikacja typu web (ASP.NET) lub desktop (WPF) napisana w języku C#
    [x] Todo list  zrealizowana jako aplika desktopowa z użyciem WPF
* aplikacja do składowania informacji powinna wykorzystywać bazę danych i korzystać z technik mapowania obiektowo-relacyjnego (ORM)
    [x] Zastosowano Entity Framework Core i zapis do lokalnej bazy MsSQL
* dodawanie/usuwanie/edycję zadań dla określonego dnia
    [x] Dodanie możliwości dodawania zadań dla danego dnia, możliwość usuwania i edycję zadań zawartych w
    bazie danych
* zmianę dnia dla którego wyświetlane są zadania
    [x] Dodano element wyboru daty i przycisk Show Task
* powiadomienia o zbliżających się zadaniach
    [x] Przycisk ShowTask pokazuje zadania, ma zaimplementowany mechanizm sprawdzania tasków 
    zaplanowanych na bieżący dzień

## Instrukcja aplikacji: 
* Do uruchomienia aplikacji konieczne jest .NET 8 i MsSQL Server
* Przed uruchomieniem aplikacji konieczne jest utworzenie tabeli w bazie danych za pomocą komendy Update-Database
    * Visual Studio Tools -> Nuget Package Manager -> Package Manager Console -> Update-Database
* Poniżej przedstawiono grafikę na której ponumerowane są odpowiednie elementy aplikacji:
    1. DatePicker do wybierania daty zadania jaka ma zostać dodana/ wyświetlona
    2. Pole Name, gdzie ustawiana jest nazwa zadania, jakie chcemy dodać lub zaktualizować
    3. Przycisk ShowTasks pokazuje zadania dla wybranego dnia, dodatkowo sprawdza czy są zadania dla dnia bieżącego (podaje ilość)
    4. Przycisk Add Task dodaje zadanie do bazy danych (dokonuje sprawdzenia czy jest coś wpisane w polu Name, jeśli nie dostajemy komunikat, 
    że należy uzupełnić to pole). Po dodaniu zadania, pole jest aktualizowane
    5. Przycisk Show All Tasks (Dodatkowy przycisk pomocniczy) pokazuje wszystkie zadania dostępne w bazie
    6. Przycisk Delete usuwa dane zadanie, i wraca do widoku dla danego dnia (wybranego w DatePicker)
    7. Przycisk Update aktualizuje nazwe zadania (sprawdzana czy pole Name jest uzupełnione), i wraca do widoku dla danego dnia (wybranego w DatePicker)
    8. Pole wyświetlające datę zadania
    9. Pole wyświetlające nazwę zadania
    10. Pole wyświetlające id zadania
![opis](https://github.com/jacekk024/teldat-recruitment-exercise/assets/45696277/3883e13e-66eb-42ad-bd83-06fee3da9f97)
* Poniżej przedstawiono wyświetlanie komunikatu o aktualnym stanie nadchodzących zadań (wyświetlana jest liczba nadchodzących zadań):
![1](https://github.com/jacekk024/teldat-recruitment-exercise/assets/45696277/df5568f4-0ce8-456b-871f-bd4dd7ebd25f)

