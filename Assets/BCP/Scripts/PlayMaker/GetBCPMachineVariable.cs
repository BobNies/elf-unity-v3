using UnityEngine;
using System;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using BCP.SimpleJSON;

/// <summary>
/// Custom PlayMaker action for MPF that sends an Event when an MPF 'machine_variable' command is received
/// (when the machine variable changes).
/// </summary>
[ActionCategory("BCP")]
[Tooltip("Retrieves the current value of an MPF machine_variable.")]
public class GetBCPMachineVariable : FsmStateAction
{
    [RequiredField]
    [UIHint(UIHint.Variable)]
    [Tooltip("The name of the MPF machine variable to retrieve")]
    public string machineVariableName;

    [UIHint(UIHint.Variable)]
    [Tooltip("The string variable to receive the value of the specified MPF machine variable")]
    public FsmString stringValue;

    [UIHint(UIHint.Variable)]
    [Tooltip("The int variable to receive the value of the specified MPF machine variable")]
    public FsmInt intValue;

    [UIHint(UIHint.Variable)]
    [Tooltip("The float variable to receive the value of the specified MPF machine variable")]
    public FsmFloat floatValue;

    [UIHint(UIHint.Variable)]
    [Tooltip("The boolean variable to receive the value of the specified MPF machine variable")]
    public FsmBool boolValue;

    /// <summary>
    /// Resets this instance to default values.
    /// </summary>
    public override void Reset()
    {
        machineVariableName = null;
        stringValue = null;
        intValue = null;
        floatValue = null;
        boolValue = null;
    }

    /// <summary>
    /// Called when the state becomes active. Adds the MPF BCP 'machine_variable' event handler.
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        if (!String.IsNullOrEmpty(machineVariableName))
        {
            JSONNode variable = BcpMessageManager.Instance.GetMachineVariable(machineVariableName);
            if (variable != null)
            {
                if (stringValue != null && !stringValue.IsNone) stringValue.Value = variable.Value;
                if (intValue != null && !intValue.IsNone) intValue.Value = variable.AsInt;
                if (floatValue != null && !floatValue.IsNone) floatValue.Value = variable.AsFloat;
                if (boolValue != null && !boolValue.IsNone) boolValue.Value = variable.AsBool;
            }
        }

        Finish();
    }

}
