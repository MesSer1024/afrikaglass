using System.Collections.Generic;

namespace Afrika
{
public static class MessageManager {
	private static List<IMessageListener> _listeners = new List<IMessageListener>();
	private static Queue<IMessage> _queue = new Queue<IMessage>();
	
	public static void AddListener (IMessageListener listener)
	{
		_listeners.Add (listener);
	}
	
	public static void RemoveListener (IMessageListener listener)
	{
		_listeners.RemoveAll (a => a == listener);
	}
	
	public static void RemoveAllListeners()
	{
		_listeners.Clear ();
	}
	
	/// <summary>
	/// Do not use this when it can be avoided
	/// Executing message DIRECTLY, not delaying for a frame etc
	/// </summary>
	public static void ExecuteMessage (IMessage msg)
	{
        var items = _listeners.ToArray();
		foreach (var listener in items) {
			listener.onMessage (msg);
		}
	}
	
	/// <summary>
	/// Will execute the message whenever it is possible to do so (usually the next frame)
	/// </summary>
	public static void QueueMessage (IMessage msg)
	{
		_queue.Enqueue(msg);
	}
	
	public static void Update ()
	{
		while (_queue.Count > 0) {
			ExecuteMessage (_queue.Dequeue ());
		}
	}
	
}
}