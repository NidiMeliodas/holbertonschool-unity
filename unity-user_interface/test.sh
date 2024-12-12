#!/bin/bash

# Dossier actuel
DIR=$(pwd)

# Parcours de tous les fichiers .cs dans le dossier courant
for FILE in "$DIR"/*.cs; do
    # Vérifie si des fichiers .cs existent
    if [ ! -e "$FILE" ]; then
        echo "Aucun fichier .cs trouvé dans le dossier courant"
        exit 0
    fi

    # Nouveau nom de fichier (enlevant .cs)
    NEWNAME="${FILE%.cs}"

    # Renomme le fichier
    mv "$FILE" "$NEWNAME"

    echo "Fichier renommé : $FILE -> $NEWNAME"
done

echo "Tous les fichiers .cs ont été renommés."
