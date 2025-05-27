#!/bin/bash

BASE_NAMESPACE="IdfOperation"

find . -name "*.cs" | while read file; do
    # קח את הנתיב המלא
    relative_path=$(dirname "$file" | sed 's|^\./||')

    # הסר קבצים מיוחדים (כמו bin/ או obj/)
    if [[ "$relative_path" == bin* || "$relative_path" == obj* ]]; then
        continue
    fi

    # המר נתיב לתוך namespace, החלף / ב־.
    namespace="$BASE_NAMESPACE"
    if [[ "$relative_path" != "." ]]; then
        folder_ns=$(echo "$relative_path" | sed 's|/|.|g')
        namespace="$namespace.$folder_ns"
    fi

    # החלף את שורת ה־namespace בקובץ
    sed -i '' "s|^namespace .*|namespace $namespace|" "$file"

    echo "✔ Updated $file → $namespace"
done

