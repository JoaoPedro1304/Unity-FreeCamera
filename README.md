# Unity New Input Actios Free Camera

**Funcionalidades**
Movimento: W, A, S, D
Subir/Descer: Space / Ctrl
Olhar ao redor: Mouse
Acelerar: Shift
Cursor travado automaticamente

**1. Configurar o Input System**

Antes do código:

Vá em Edit > Project Settings > Player
Em Active Input Handling, selecione:
Input System Package (New) ou Both
Instale o pacote:
Window > Package Manager > Input System

2. Criar Input Actions

Você precisa criar um Input Actions Asset:

Nome: CameraActions

Crie um Action Map chamado Camera com:

Action	Tipo	Binding
Move	Value (Vector2)	WASD
Look	Value (Vector2)	Mouse Delta
Up	Button	Space
Down	Button	Ctrl
Fast	Button	Shift

Depois de criar o Input Actions:

Clique em "Generate C# Class"
Isso vai gerar automaticamente a classe CameraActions usada no script

 3. Script para Free Camera

 Adicione o script FreeCamera.cs na camera principal do projeto script: ./Assets/Scripts