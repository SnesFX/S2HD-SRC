using System;

namespace SonicOrca
{
	// Token: 0x02000093 RID: 147
	internal class FiniteStateMachine
	{
		// Token: 0x06000316 RID: 790 RVA: 0x00016AB4 File Offset: 0x00014CB4
		public FiniteStateMachine.IState Begin()
		{
			this._reInitialised = true;
			return this._currentState = new FiniteStateMachine.State(this);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00016AD7 File Offset: 0x00014CD7
		public void Finish()
		{
			this._reInitialised = true;
			this._currentState = null;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00016AE8 File Offset: 0x00014CE8
		public bool Update()
		{
			if (this._currentState == null)
			{
				return false;
			}
			this._reInitialised = false;
			FiniteStateMachine.State currentState = this._currentState.Update();
			if (!this._reInitialised)
			{
				this._currentState = currentState;
			}
			return true;
		}

		// Token: 0x040003E2 RID: 994
		private FiniteStateMachine.State _currentState;

		// Token: 0x040003E3 RID: 995
		private bool _reInitialised;

		// Token: 0x02000104 RID: 260
		public interface IState
		{
			// Token: 0x0600064F RID: 1615
			FiniteStateMachine.IState Do(Action action);

			// Token: 0x06000650 RID: 1616
			FiniteStateMachine.IState While(Func<bool> condition);

			// Token: 0x06000651 RID: 1617
			FiniteStateMachine.IState While(Func<bool> condition, Action action);

			// Token: 0x06000652 RID: 1618
			FiniteStateMachine.IState Wait(int ticks);
		}

		// Token: 0x02000105 RID: 261
		private class State : FiniteStateMachine.IState
		{
			// Token: 0x06000653 RID: 1619 RVA: 0x000260BF File Offset: 0x000242BF
			public State(FiniteStateMachine finiteStateMachine)
			{
				this._finiteStateMachine = finiteStateMachine;
			}

			// Token: 0x06000654 RID: 1620 RVA: 0x000260CE File Offset: 0x000242CE
			private State(FiniteStateMachine finiteStateMachine, Action action)
			{
				this._finiteStateMachine = finiteStateMachine;
				this._action = action;
			}

			// Token: 0x06000655 RID: 1621 RVA: 0x000260E4 File Offset: 0x000242E4
			public FiniteStateMachine.State Update()
			{
				if (this._finiteStateMachine._reInitialised)
				{
					return null;
				}
				if (this._action == null)
				{
					if (this._next == null)
					{
						return null;
					}
					return this._next.Update();
				}
				else
				{
					this._action();
					if (!this._finished)
					{
						return this;
					}
					if (this._next != null)
					{
						return this._next.Update();
					}
					return null;
				}
			}

			// Token: 0x06000656 RID: 1622 RVA: 0x00026148 File Offset: 0x00024348
			public FiniteStateMachine.IState Do(Action action)
			{
				FiniteStateMachine.State state = new FiniteStateMachine.State(this._finiteStateMachine, action);
				state._finished = true;
				FiniteStateMachine.State result = state;
				this._next = state;
				return result;
			}

			// Token: 0x06000657 RID: 1623 RVA: 0x00026174 File Offset: 0x00024374
			public FiniteStateMachine.IState While(Func<bool> condition)
			{
				return this._next = new FiniteStateMachine.State(this._finiteStateMachine, delegate()
				{
					if (!condition())
					{
						this._next._finished = true;
					}
				});
			}

			// Token: 0x06000658 RID: 1624 RVA: 0x000261B8 File Offset: 0x000243B8
			public FiniteStateMachine.IState While(Func<bool> condition, Action action)
			{
				return this._next = new FiniteStateMachine.State(this._finiteStateMachine, delegate()
				{
					if (condition())
					{
						action();
						return;
					}
					this._next._finished = true;
				});
			}

			// Token: 0x06000659 RID: 1625 RVA: 0x00026200 File Offset: 0x00024400
			public FiniteStateMachine.IState Wait(int ticks)
			{
				return this._next = new FiniteStateMachine.State(this._finiteStateMachine, delegate()
				{
					int ticks2 = ticks;
					ticks = ticks2 - 1;
					if (ticks2 <= 0)
					{
						this._next._finished = true;
					}
				});
			}

			// Token: 0x0400069D RID: 1693
			private readonly FiniteStateMachine _finiteStateMachine;

			// Token: 0x0400069E RID: 1694
			private readonly Action _action;

			// Token: 0x0400069F RID: 1695
			private FiniteStateMachine.State _next;

			// Token: 0x040006A0 RID: 1696
			private bool _finished;
		}
	}
}
