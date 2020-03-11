using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Yerel.Entities;

namespace Yerel.aws.Infrastructure
{
    public class OnlineUsers
    {
        // Singleton instance
        private readonly static Lazy<OnlineUsers> _instance = new Lazy<OnlineUsers>(
            () => new OnlineUsers(GlobalHost.ConnectionManager.GetHubContext<MyHub>().Clients));

        private readonly object _streamStateLock = new object();
        private readonly object _updateApiDataLock = new object();
        private readonly object _updateSentDataLock = new object();

        private static readonly ConcurrentDictionary<string, User> _apiDataList = new ConcurrentDictionary<string, User>();

        private const int SentListMax = 50;
        private Queue<User> q = new Queue<User>();
        //private static readonly ConcurrentDictionary<int, SendDataApi> _sentList = new ConcurrentDictionary<int, SendDataApi>();

        private readonly Random _updateOrNotRandom = new Random();

        private volatile bool _updatingApiDataList;
        private volatile StreamState _streamState;
        private IHubConnectionContext<dynamic> clients;

        public OnlineUsers(IHubConnectionContext<dynamic> clients)
        {
            this.clients = clients;
        }

        private OnlineUsers(HubConnectionContext clients)
        {
            Clients = clients;
        }

        public static OnlineUsers Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private HubConnectionContext Clients
        {
            get;
            set;
        }

        public StreamState StreamState
        {
            get { return _streamState; }
            private set { _streamState = value; }
        }

        public void OpenStream()
        {
            lock (_streamStateLock)
            {
                if (StreamState != StreamState.Open)
                {
                    StreamState = StreamState.Open;
                    BroadcastStreamStateChange(StreamState.Open);
                }
            }
        }

        public void CloseStream()
        {
            lock (_streamStateLock)
            {
                if (StreamState == StreamState.Open)
                {
                    StreamState = StreamState.Closed;

                    BroadcastStreamStateChange(StreamState.Closed);
                }
            }
        }

        public void Reset()
        {
            lock (_streamStateLock)
            {
                if (StreamState != StreamState.Closed)
                {
                    throw new InvalidOperationException("Stream must be closed before it can be reset.");
                }

                GetAllApiData();
                BroadcastStreamReset();
            }
        }

        public IEnumerable<User> GetAllApiData()
        {
            //BroadcastApiCount();
            return _apiDataList.Values;
        }

        public void Put(User apiData)
        {
            //lock (_updateApiDataLock)
            //{
                _apiDataList.TryAdd(apiData.Name, apiData);
                //BroadcastApiData(apiData, ActionMethod.Put);
            //}
        }

        public void Delete(User data)
        {
            lock (_updateApiDataLock)
            {
                if (!_updatingApiDataList)
                {
                    _updatingApiDataList = true;
                    User apiData;
                    _apiDataList.TryRemove(data.Name, out apiData);
                    BroadcastApiData(apiData, ActionMethod.Delete);

                    _updatingApiDataList = false;
                }
            }
        }

        private void BroadcastStreamStateChange(StreamState streamState)
        {
            switch (streamState)
            {
                case StreamState.Open:
                    Clients.All.streamOpened();
                    break;
                case StreamState.Closed:
                    Clients.All.streamClosed();
                    break;
                default:
                    break;
            }
        }

        private void BroadcastStreamReset()
        {
            Clients.All.streamReset();
        }

        private void BroadcastApiData(User data, ActionMethod method)
        {
            switch (method)
            {
                case ActionMethod.Put:
                    Clients.All.putApiData(data);
                    BroadcastApiCount();
                    break;
                case ActionMethod.Delete:
                    Clients.All.deleteApiData(data);
                    BroadcastApiCount();
                    break;
                default:
                    break;
            }
        }

        private void BroadcastSentDataApi(User data, ActionMethod method)
        {
            switch (method)
            {
                case ActionMethod.Put:
                    Clients.All.putSentDataApi(data);
                    break;
                case ActionMethod.Delete:
                    Clients.All.deleteSentDataApi(data);
                    break;
                default:
                    break;
            }
        }

        private void BroadcastApiCount()
        {
            Clients.All.dataCount(_apiDataList.Count);
        }

        internal IEnumerable<User> GetAllSentData()
        {
            //return _sentList.Values;
            return q.ToList();
        }

        //internal void Put(Product value)
        //{
        //    lock (_updateSentDataLock)
        //    {
        //        if (q.Count() == SentListMax)
        //        {
        //            q.Dequeue();
        //            //SendDataApi dt;                    
        //            //_sentList.TryRemove(_sentList.First().Key, out dt);
        //        }

        //        q.Enqueue(value);
        //        //_sentList.TryAdd(listID++, value);
        //        BroadcastSentDataApi(value, ActionMethod.Put);
        //    }
        //}
    }

    public enum StreamState
    {
        Closed,
        Open
    }

    public enum ActionMethod
    {
        Put,
        Delete
    }
}