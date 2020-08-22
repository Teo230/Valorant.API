# Valorant.Rest.API
This .dll provides all the request that you need to retrieve data from Valorant

## How to use
To make any request, you need to create a **ValorantClient** object with **HttpClient** session
`clientVersion` parameter at the moment you can select one from this [Link](https://github.com/RumbleMike/ValorantAPI/blob/master/Docs/ClientVersions.md)

```c#
HttpClient session = new HttpClient();
var valorantClient = new ValorantClient(session, clientVersion);
```

When you create the valorantClient, you are enable to make the first request to retrieve the **Bearer Token**

```c#
UserParametersDTO userParameter = valorantClient.GetUserParameters();
```

Inside **userParameters** you can find a sub-properties called `uri` that contain the **Bearer Token** (access_token)
```json
"uri": "https://beta.playvalorant.com/opt_in#access_token=herethereisthetoken&scope=openid&id_token=herethereistheidtoken&token_type=Bearer&expires_in=3600"
```

Once you saved the BearerToken, you need to add to `session` as header and re-create the `ValorantClient`

```c#
session.DefaultRequestHeaders.Add("Authorization", "Bearer " + BearerToken);
var valorantClient = new ValorantClient(session, clientVersion);
```

Now you can request the **EntitlementsToken**

```c#
string EntitlementsToken = valorantClient.GetEntitlementsToken();
```

Add also EntitlementsToken to `session` as header and re-create the `ValorantClient`
```c#
session.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", EntitlementsToken);
var valorantClient = new ValorantClient(session, clientVersion);
```

Now you are ready to make all the other request!

# Request Available
- GetUserParameters
- GetEntitlementsToken
- GetPlayer
- GetMatches
- GetBalance
- GetCompetitiveMatch
- GetPlayerMMR
- GetPlayerStore
- GetStoryContract
- GetIDList

# Request to be provide by Riot
- Player Inventory
- Match Info

All these requests are documentated by [@RumbleMike](https://github.com/RumbleMike) on this [Link](https://github.com/RumbleMike/ValorantAPI)
