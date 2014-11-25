// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.StateMachine;


public class MovementStateMachineBase : Invert.StateMachine.StateMachine {
    
    private StateMachineTrigger _MoveTransition;
    
    private StateMachineTrigger _StopTransition;
    
    private Idle _Idle;
    
    private Move _Move;
    
    public MovementStateMachineBase(ViewModel vm, string propertyName) : 
            base(vm, propertyName) {
    }
    
    public virtual StateMachineTrigger MoveTransition {
        get {
            if ((this._MoveTransition == null)) {
                this._MoveTransition = new StateMachineTrigger(this, "MoveTransition");
            }
            return this._MoveTransition;
        }
    }
    
    public virtual StateMachineTrigger StopTransition {
        get {
            if ((this._StopTransition == null)) {
                this._StopTransition = new StateMachineTrigger(this, "StopTransition");
            }
            return this._StopTransition;
        }
    }
    
    public virtual Idle Idle {
        get {
            if ((this._Idle == null)) {
                this._Idle = new Idle();
            }
            return this._Idle;
        }
    }
    
    public virtual Move Move {
        get {
            if ((this._Move == null)) {
                this._Move = new Move();
            }
            return this._Move;
        }
    }
    
    public override void Compose(List<State> states) {
        base.Compose(states);
        this.Idle.StateMachine = this;
        Idle.MoveTransition = new StateTransition("MoveTransition", Idle,Move);
        Idle.AddTrigger(MoveTransition, Idle.MoveTransition);
        states.Add(Idle);
        this.Move.StateMachine = this;
        Move.StopTransition = new StateTransition("StopTransition", Move,Idle);
        Move.AddTrigger(StopTransition, Move.StopTransition);
        states.Add(Move);
    }
}

public class FireStateMachineBase : Invert.StateMachine.StateMachine {
    
    private StateMachineTrigger _FireTransition;
    
    private StateMachineTrigger _StopTransition;
    
    private Stop _Stop;
    
    private Fire _Fire;
    
    public FireStateMachineBase(ViewModel vm, string propertyName) : 
            base(vm, propertyName) {
    }
    
    public virtual StateMachineTrigger FireTransition {
        get {
            if ((this._FireTransition == null)) {
                this._FireTransition = new StateMachineTrigger(this, "FireTransition");
            }
            return this._FireTransition;
        }
    }
    
    public virtual StateMachineTrigger StopTransition {
        get {
            if ((this._StopTransition == null)) {
                this._StopTransition = new StateMachineTrigger(this, "StopTransition");
            }
            return this._StopTransition;
        }
    }
    
    public virtual Stop Stop {
        get {
            if ((this._Stop == null)) {
                this._Stop = new Stop();
            }
            return this._Stop;
        }
    }
    
    public virtual Fire Fire {
        get {
            if ((this._Fire == null)) {
                this._Fire = new Fire();
            }
            return this._Fire;
        }
    }
    
    public override void Compose(List<State> states) {
        base.Compose(states);
        this.Stop.StateMachine = this;
        Stop.FireTransition = new StateTransition("FireTransition", Stop,Fire);
        Stop.AddTrigger(FireTransition, Stop.FireTransition);
        states.Add(Stop);
        this.Fire.StateMachine = this;
        Fire.StopTransition = new StateTransition("StopTransition", Fire,Stop);
        Fire.AddTrigger(StopTransition, Fire.StopTransition);
        states.Add(Fire);
    }
}

public class Idle : Invert.StateMachine.State {
    
    private StateTransition _MoveTransition;
    
    public virtual StateTransition MoveTransition {
        get {
            return this._MoveTransition;
        }
        set {
            _MoveTransition = value;
        }
    }
    
    public override string Name {
        get {
            return "Idle";
        }
    }
    
    private void MoveTransitionTransition() {
        this.Transition(this.MoveTransition);
    }
}

public class Move : Invert.StateMachine.State {
    
    private StateTransition _StopTransition;
    
    public virtual StateTransition StopTransition {
        get {
            return this._StopTransition;
        }
        set {
            _StopTransition = value;
        }
    }
    
    public override string Name {
        get {
            return "Move";
        }
    }
    
    private void StopTransitionTransition() {
        this.Transition(this.StopTransition);
    }
}

public class Stop : Invert.StateMachine.State {
    
    private StateTransition _FireTransition;
    
    public virtual StateTransition FireTransition {
        get {
            return this._FireTransition;
        }
        set {
            _FireTransition = value;
        }
    }
    
    public override string Name {
        get {
            return "Stop";
        }
    }
    
    private void FireTransitionTransition() {
        this.Transition(this.FireTransition);
    }
}

public class Fire : Invert.StateMachine.State {
    
    private StateTransition _StopTransition;
    
    public virtual StateTransition StopTransition {
        get {
            return this._StopTransition;
        }
        set {
            _StopTransition = value;
        }
    }
    
    public override string Name {
        get {
            return "Fire";
        }
    }
    
    private void StopTransitionTransition() {
        this.Transition(this.StopTransition);
    }
}