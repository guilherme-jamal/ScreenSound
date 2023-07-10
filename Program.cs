string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("\n" + mensagemDeBoasVindas);
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //Função 
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirMenuDeOpcoes()
{
    ExibirLogo();

    Console.WriteLine(@"
█▀▄▀█ █▀▀ █▄░█ █░█   █▀█ █▀█ █ █▄░█ █▀▀ █ █▀█ ▄▀█ █░░
█░▀░█ ██▄ █░▀█ █▄█   █▀▀ █▀▄ █ █░▀█ █▄▄ █ █▀▀ █▀█ █▄▄");
    Console.WriteLine("\n1 - Registrar banda");
    Console.WriteLine("2 - Mostrar todas as bandas");
    Console.WriteLine("3 - Avaliar banda");
    Console.WriteLine("4 - Exbibir média de uma banda");
    Console.WriteLine("5 - Sair do menu");

    Console.Write("\nDigite a opção: ");
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);

    switch (opcaoEscolhida)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarTodasAsBandas();
            break;
        case 3:
            AvaliarBandaRegistrada();
            break;
        case 4:
            ExibirMedia();
            break;
        case 5:
            Console.WriteLine("Volte sempre! :)");
            break;
        default:
            Console.WriteLine("Opção Inválida!");
            break;
    }

}

ExibirMenuDeOpcoes();

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>()); //Para registrar uma banda no dicionário, abrindo uma lista para ela
    Thread.Sleep(2000); // Para dar um tempo até rodar a próximo comando
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");

    Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();

}

void MostrarTodasAsBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibição das bandas registradas");

    /*for (int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }*/
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void AvaliarBandaRegistrada()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliação de bandas");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) //Para verificar se encontra
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); //Para acessar os valores da lista de inteiro
        Thread.Sleep(1000);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso!");

        Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();

    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
}

