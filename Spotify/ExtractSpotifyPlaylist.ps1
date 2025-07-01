$xml = [xml](Get-Content -Path "./file.html")


$items = $xml.SelectNodes('//div[@data-testid="tracklist-row"]')
$index = $items.Count

foreach ($node in $items) {
    $songName = $node.div[1].div.a.div.'#text'
    $artistName = $node.div[2].span.div.a.'#text'

    if (-not $songName -or -not $artistName) {
        $index--
        continue
    }

    if ($artistName -is [array]) {
        $artistName = $artistName[0]
    }

    @{
        "Song"   = $songName.Trim()
        "Artist" = $artistName.Trim()
        "Index"  = $index
    }

    $index--
}