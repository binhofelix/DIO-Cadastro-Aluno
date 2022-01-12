﻿using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            var indicealuno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();            

            while (opcaoUsuario.ToUpper() != "X")
            {                
                switch (opcaoUsuario)
                {
                    case "1":
                        //Adicionar aluno
                        Console.Clear();
                        Console.WriteLine("Selecionou: 1");
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("VAlor da nota deve ser em decimal!");
                        }

                        alunos[indicealuno] = aluno;
                        indicealuno++;


                        break;
                    case "2":
                        //Listar alunos
                        Console.Clear();
                        Console.WriteLine("Selecionou: 2");
                        foreach (var a in alunos)
                        {                            
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine("ALUNO: " + a.Nome + " / Nota: " + a.Nota);
                            }

                        }
                        break;
                    case "3":
                        //Calcular média geral
                        Console.Clear();
                        Console.WriteLine("Selecionou: 3");
                        decimal notaTotal = 0;
                        var numAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                numAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / numAlunos;
                        Conceito conceitoGeral;
                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MEDIA GERAL: {mediaGeral.ToString("F")} - Conceito: {conceitoGeral}");                        

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {            
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Inserir Aluno");
            Console.WriteLine("2 - Listar Aluno");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
