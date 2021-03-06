# ComicList ASP.NET Core Project
Проектът ми по ASP.NET е направен на ASP.NET Core Framework(последна версия).
Темата на проекта е "MyComicList" - Моят Комикс Лист.

Видеоклип показващ уеб частта на проекта: https://youtu.be/3b6vsIBcpHY :cinema:

  Проектът ми по ASP.NET е направен на ASP.NET Core Framework(последна версия). Темата на проекта е "MyComicList" - Моят Комикс Лист.
Потребителите могат да разглеждат комикси без да се регистрират в сайта. В него потребителите могат да добавят комикси в любими и 
да виждат всички техни любими комикси на едно място.
В сайтът има и търсачка, която прави по-лесно търсенето на комикси. Тази опция обаче изисква потребителят да има роля "Admin".
Ако в търсачка искаме да търсим някой комикс няма да ни бъде позволено. Ще получим съъобщение Access denied. 
При регистрация всички потребители получават роля User автоматично.User няма право да използва търсачката.
Само профили създадени от DbInitializer -> методът SeedUsers може да получат роля админ.

####  Проектът е разделен на 3 отделни папки. Всяка от тях представлява различен проект, но всички са обединени в един Solution - MyComicList.

  Първата част е DataStrucure която е от тип Class Library - Библиотека. В нея са събрани главните моделите.Там се намират Author(Автори),Comic(Комикс),FavoriteListItem(Любим комикс),Genre(Жанр),
Origin (Произход - Например дали е Корейски или Японски).
Всеки един от тях е публичен за да може да бъде достъпван от други места.

  Втората част е DataAccess.Тя също е от тип Class Library - Библиотека. В нея са събрани Interfaces,Migrations,Repositories,Services както и cs-файловете ApplicationDbContext и DbInitializer.
В Interfaces се намират колекциите на различните модели. 
В Migrations се намират миграциите на базата ми. 
В servies се намира услугата FavoriteService, чрез която се добавя,маха комикс от любими.
Repositories наследява Interface-ите за по-лесно достъпване на колекциите.
	За да имаме достъп до SQL база данни в ASP.NET application ние се нуждаем от ApplicationDbContext. Той свързва базата с нашите модели. Там също са добавени и ролите за Admin и User. 
ApplicationDbContext имплементира класът IdentityDbContext.
В DbInitializer изпалзвайки Dictonary и AddRange са добавени всички стойности за Комикси,Автори,Студиота,Произходи. На края е използван методът SeedUser с който се добавят акаунти, които
имат роля на админ.

  Третата част MyComicList е най-главната част от проекта. Проектът е направен използвайки MVC - Models Views Controllers 
Models - е съвкупонст от колекциите на DataStructure за да бъдат използвани по лесно от контролерите.
Контролерите AuthorController,GenreController,OriginController задават кой комикс с какво да бъде свързан. Използвана е връзката едно към много.
Всеки един Author,Genre,Origin има по няколко комикса.
FavoriteListController - дава възможност на потребителя да добавя и маха комикси от любими.
  В папка Components репозиторитата са извикани - Invoke. За да може ние да ги видим в сайтът.
В папка Views се намират cshtml файловете с които ние даваме дизайн и подреждаме сайт-ът ни използвайки и html и c# код.
Използвани са много partial-view-та с цел да се спести код. 
  Скафолднато е Identity като една от промените му е когато е регистриран потребител да му бъде назначена рола User.
  В Startup файла за зададени routes за всеки контролер. На краят на файла са извикани методите Seed и SeedUser за да 
може проектът да зареди от някъде информацията за комикси и кои потребители са администратори.

Използван е bootstrap-stape - Superhero от https://bootswatch.com/ 
  
  В SQL може да се видят диаграмите. На първата снимка е показана моята ръчно създадена диаграма. При нея връзките са едно към много.
Origins,Authors,Genres могат да имат много комикси. 

![Picture 1](https://i.imgur.com/PfO54dX.png)

  На втората снимка се вижда автоматично генерираните таблици от Individual Authentication. AspNetUserRoles е свързана с AspNetUsers и 
AspNetRoles. Тяхната връзка е много към много.

![Picture 2](https://i.imgur.com/aRDeVLX.png)
