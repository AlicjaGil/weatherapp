Zastosowano dwa typy tagów:
latest – wskazuje najnowszą wersję obrazu,
sha – tag oparty o hash commitu, pozwalający jednoznacznie zidentyfikować konkretną wersję aplikacji.
Cache
Do przyspieszenia procesu budowania wykorzystano cache Buildx przechowywany w publicznym repozytorium Docker Hub. Cache jest pobierany przed budową (cache-from) oraz aktualizowany po zakończeniu procesu.
Dockerfile
Zastosowano wieloetapowy Dockerfile (Multi-Stage Build). W pierwszym etapie aplikacja .NET jest kompilowana i publikowana, natomiast w drugim tworzony jest docelowy obraz uruchomieniowy oparty na aspnet:10.0-alpine. Dzięki temu końcowy obraz jest mniejszy i nie zawiera narzędzi programistycznych.
Dodatkowo skonfigurowano:
HEALTHCHECK sprawdzający dostępność aplikacji na porcie 8080,
metadane OCI zawierające autora oraz adres repozytorium źródłowego.
