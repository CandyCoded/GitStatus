# GitStatus

> Unity editor panel that displays the current git status.

[![npm](https://img.shields.io/npm/v/xyz.candycoded.gitstatus)](https://www.npmjs.com/package/xyz.candycoded.gitstatus)

<img src="Screenshots/editorpanel.png" width="400">

## Install

### Unity Package Manager

#### Git

```json
{
  "dependencies": {
    "xyz.candycoded.gitstatus": "https://github.com/CandyCoded/gitstatus.git#v1.1.0",
    ...
  }
}
```

#### Scoped UPM Registry

```json
{
  "dependencies": {
    "xyz.candycoded.gitstatus": "1.1.0",
    ...
  },
  "scopedRegistries": [
    {
      "name": "candycoded",
      "url": "https://registry.npmjs.com",
      "scopes": ["xyz.candycoded"]
    }
  ]
}
