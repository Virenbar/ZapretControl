# ZapretControl - GUI для [zapret-discord-youtube](https://github.com/Flowseal/zapret-discord-youtube)

Небольшой GUI для запуска скриптов для Zapret

Исполняемый файл и скрипты взяты напрямую из оригинального репозитория через git submodule.

## Скриншоты

Основное окно  
![main](./assets/main.ru.png)

Меню в трее  
![tray](./assets/tray.ru.png)

## Заметки

* .NET 6 - Windows 7 ([Нужен старый WinDivert][win7])
* .NET 8 - Windows 10+

```sh
# Обновление submodule
git submodule update --recursive --remote
```

```sh
# Локальная публикация (Публикация в папку сломана в VS)
dotnet publish -c Release -p:PublishProfile=net6 -f net6.0-windows /property:Version=1.*.*
dotnet publish -c Release -p:PublishProfile=net8 -f net8.0-windows /property:Version=1.*.*
```

## Ссылки

* **[zapret-discord-youtube](https://github.com/Flowseal/zapret-discord-youtube)** by @Flowseal
* **[zapret](https://github.com/bol-van/zapret)** by @bol-van
* **[WinDivert](https://github.com/basil00/Divert)** by @basil00

<!-- URL -->
[win7]: https://github.com/Flowseal/zapret-discord-youtube?tab=readme-ov-file#требуется-цифровая-подпись-драйвера-windivert-windows-7
