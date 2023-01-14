# Installer la librairi
python -m pip install "pymongo[srv]"

# Importation de la librari
from pymongo import MongoClient
# print + saut de ligne
import pprint

# connexion à Mongo
client = MongoClient("mongodb://localhost:27017")
# récupération d'une db
db = client["ny"]
# récupération d'une collection
collection_name = db["restaurants"]

# création d'un document
item = {
  "maClef" : "piloupilou"
}
item2 = {
  "maClef" : "pilou"
}

# insertion d'un document
collection_name.insert_one(item)

# insertion de plusieurs documents
collection_name.insert_many([item2])

# suppression d'un document
collection_name.delete_one({"maClef":"pilou"})

# suppression d'un document
collection_name.update_one({"maClef":"piloupilou"},{"$set": { "status": "Modified"}})

# requête simple
item_details = collection_name.find()
for item in item_details:
   print(item)

# creation d'index
category_index = collection_name.create_index("category")

# Aggregation
pipeline = [
    { "$unwind": "$grades" },
    { "$group": { "_id": "$name", "avg_by_restaurant": { "$avg": "$grades.score" } } },
    { "$sort": { "avg_by_restaurant": -1 }} ,
    {"$limit":3}
]
pprint.pprint(list(db.restaurants.aggregate(pipeline)))