clean:
	git clean -xdf

deploy:
	git subtree push --prefix Assets/Plugins/CandyCoded.GitStatus origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/Plugins/CandyCoded.GitStatus master`:upm --force
