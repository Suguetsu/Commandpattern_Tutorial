using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public interface ICommand
    {
        void Execute();
        void Undo();




    }

    public interface ICommand2 { void Capture(); void Undo(); }


    public static CommandManager Instance { get; private set; }

    private Stack<ICommand> m_CommandsBuffer = new Stack<ICommand>();
    private Stack<ICommand2> m_Out = new Stack<ICommand2>();



    private void Awake()
    {
        Instance = this;
    }

    public void AddCommand(ICommand command)
    {
        command.Execute();
        m_CommandsBuffer.Push(command);
    }
    public void AdOut(ICommand2 command)
    {
        command.Capture();
        m_Out.Push(command);
    }


    public void Undo()
    {
        if (m_CommandsBuffer.Count == 0)
        {
            return;
        }

        var cmd = m_CommandsBuffer.Pop();

        cmd.Undo();
    }

    public void UndoTarget()
    {
        if (m_Out.Count == 0)
        {
            return;
        }

        var cmd = m_Out.Pop();

        cmd.Undo();
    }
}
