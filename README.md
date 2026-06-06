**Zastosowano dwa typy tagów:**<br/>
latest – wskazuje najnowszą wersję obrazu,
sha – tag oparty o hash commitu, pozwalający jednoznacznie zidentyfikować konkretną wersję aplikacji.<br/><br/>
**Cache**<br/>
Do przyspieszenia procesu budowania wykorzystano cache Buildx przechowywany w publicznym repozytorium Docker Hub. Cache jest pobierany przed budową (cache-from) oraz aktualizowany po zakończeniu procesu.<br/><br/>
**Dockerfile**<br/>
Zastosowano wieloetapowy Dockerfile (Multi-Stage Build). W pierwszym etapie aplikacja .NET jest kompilowana i publikowana, natomiast w drugim tworzony jest docelowy obraz uruchomieniowy oparty na aspnet:10.0-alpine. Dzięki temu końcowy obraz jest mniejszy i nie zawiera narzędzi programistycznych.<br/><br/>
**Dodatkowo skonfigurowano:**<br/>
HEALTHCHECK sprawdzający dostępność aplikacji na porcie 8080,
metadane OCI zawierające autora oraz adres repozytorium źródłowego.<br/><br/>
