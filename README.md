# ol-proxy-health-checker
Proxy Health Checker app. Tech task.

Užduoties vykdymo procesas buvo gana paprastas: "užsisukti" projeką ir pradėti 
bottom-up: įsidejau mygtuka ir pradėjau nuo paprasto varianto, kuris darytų 
minimaliai ko reikalaujama (atliktu užklausas per proxy). Sekantis žingsnis buvo 
susitvarkyti strūturą ir peržvelgti, ką dar galečiau spėti atlikti iš pateikto sąrašo. 
Mano supratimu, neatlikau tik tamsios temos palaikymo ir "auto-refresh".

Kas galejo buti atlikta geriau, tai istorijos saugojimas. Modeliai ir pati "domeno" 
struktūra yra tokia dėl bandymo išlaikyti minimalų papildomų paketų 
naudojimą.

Minimalus paketų (nuget) naudojimo poreikis atsirado dėl vieno iš reikalavimų: 
naudoti .Net Framework ir/arba .Net Standard. Kadangi, tai jau gana pasenę
"targetai", buvo sunku nuspėti, kas veiks, kas ne ir kokias versijas geriausiai 
pasirinkti (nemažai bibliotekų, kurias naudodavau, turi "vulnerabilicių" ir pan.). 
Manau, tai ir buvo didžiausias iššukis (be to, kad jau kuris laikas neteko nieko 
rimto programuoti su WPF).

Taip pat, UI buvo galima panaudoti puslapius, buvo galima pridėti stilius temoms ir pan.
