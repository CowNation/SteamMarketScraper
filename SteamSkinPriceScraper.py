# - # - # - # - # - # - # - # - # -# - # - # - # - # - # - # - # - # - #
import urllib.request, json
import enum
FN = " (Factory New)"
MW = " (Minimal Wear)"
FT = " (Field-Tested)"
WW = " (Well-Worn)"
BS = " (Battle-Scarred)"
class AppId(enum.Enum):
  CSGO = 730
  TF2 = 440
  DOTA2 = 570
  PUBG = 578080
  H1Z1 = 433850
  UNTURNED = 304930
  RUST = 252490
class MarketItem():
  sucess = False
  lowest_price = ""
  median_price = ""
  name = ""
def GetMarketItem(appid, name): 
  url = urllib.request.urlopen("http://steamcommunity.com/market/priceoverview/?appid=%s&currency=1&market_hash_name=" % appid + name)
  data = json.loads(url.read().decode())
  strdat = str(data)
  Item = MarketItem()
  if (strdat.find("'success': False") == -1):
    Item.sucess = True
    Item.name = name
  if (strdat.find('median_price') != -1):
    Item.median_price = strdat[strdat.find('median_price')+16:-2]
  if (strdat.find('lowest_price') != -1):
    Item.lowest_price = strdat[strdat.find('lowest_price')+16:-2]
  return Item
def PrintMarketItem(it):
  if (len(it.name) > 0):
    print(it.name + ": ")
  if (len(it.median_price) > 0):
    print(it.median_price)
  elif (len(it.lowest_price) > 0):
    print(it.lowest_price)
  else:
    print("No valid price found!")
# - # - # - # - # - # - # - # - # -# - # - # - # - # - # - # - # - # - #
it = GetMarketItem(AppId.CSGO.value, "AWP | Dragon Lore" + FT)
PrintMarketItem(it)

it = GetMarketItem(AppId.TF2.value, "Mann Co. Supply Crate Key")
PrintMarketItem(it)

it = GetMarketItem(AppId.DOTA2.value, "Sylvan Vedette")
PrintMarketItem(it)

it = GetMarketItem(AppId.PUBG.value, "RAIDER CRATE")
PrintMarketItem(it)

it = GetMarketItem(AppId.H1Z1.value, "Anarchy Leather Pants")
PrintMarketItem(it)

it = GetMarketItem(AppId.UNTURNED.value, "Pilot Aviators")
PrintMarketItem(it)

it = GetMarketItem(AppId.RUST.value, "High Quality Bag")
PrintMarketItem(it)
