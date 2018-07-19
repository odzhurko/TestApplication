Aplikacja pisana w Visual studio 2017 w .NET Core 2.0

Żeby aplikacja wstała popranwnie należy wykonać następne czynności:
1. Po pobraniu z repo należy zaistalować wszystkie zarejestrowane paczky NuGet. Dla tego 
	klikamy prawym przyciskiem po solucji i wybieramy "Restore NuGet Packages";
2. Należy utworzyć bazędanych. 
	2.1 Dla tego w pliku solucji o nazwie "Installers" zminiamy na 	własny connectionString. 
	Czyli wkazujemy server gdzie powinna powstać baza. Domyślnie uztawiany jest lokalny server.
	2.2 W "Package Manager Console" wpisujem polecenia "Add-Migration InitialCreate" a później "Update-Database"
	2.3 Można zalogować się na server bazodanowy i sprawdzić czy baza powstała. 
3. Odpalamy TestApi.WebApi. Dla pracy z WebApi w Repositorium jest plik kolecji Postman o nazwie "TestApp Collections.postman_collection.json".
	Należy ten plik zaimpoorwować do własnej aplikacji i dodać zmienną "ApiHost". Ta zmienna oznacza host na którym 
	powstało WebApi. A moim przypadku to "http://localhost:55872/".
4. Skoro baza jest dopiero stworzona to ona nie zawiera danych. "Fill Default Data" request uzupełnia baze danymi. 
	Warto pamiętaż że wyłołanie tego EndPointu usuwa wszystkie wczaśniejsze dane i resetuje inkrementatory. 
	Zrobiono to celowo żeby nie było póżniej żadnuch niespójności z kluczami obcymi. 
5. Kolejne Requesty pokazują w jaki sposób dane są pobierane WebApi i w jaki sposób dodajemy nowe wpisy do bazy.
6. Pobieranie wszystkich identyfikatorów używa stronicowania. Warto o tym pamiętać. Jeśli PageNumber będzie mniejszy 0
	to będzie błąd walidacyjny.
7. Response z servera przychodzi w postaci {Error, Data}. Gdzie DATA to jest ten obiekt o który "pytamy" a ERROR 
	się pojawi tylko w tedy kidy będzie błąd po stronie servera
8. Aplikacja konsolowa działą następująco:
	8.1 Uruchamiamy project TestApp.ConsoleApp
	8.2 Aplikacja rejestruje wszystkie zależności
	8.3 Odczytuje dane z pliku ToGenerate.json i deserializuje dane
	8.4 Przewraza bazę do danych domyślnych
	8.5 Dokonuje generowania nowym identyfikatorów i zapisanie ich do bazy.
	8.6 zapisuje nowe dane do pliku "TestApp.ConsoleApp\bin\Debug\netcoreapp2.0\Config\AfterGenerate.json"
9. Żeby uruchomić test należy kliknąć w VS2017 Test w menu górnym i wybrać Run->All tests
10. W jednym miejscu użyłem kastomowych walidatorów. 
