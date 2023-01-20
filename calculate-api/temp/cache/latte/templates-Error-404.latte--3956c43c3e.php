<?php

use Latte\Runtime as LR;

/** source: D:\wamp64\www\kalkulačka -  appmobile\mobilniKalkulacka\calculate-api\app\Presenters/templates/Error/404.latte */
final class Template3956c43c3e extends Latte\Runtime\Template
{
	protected const BLOCKS = [
		['content' => 'blockContent', 'title' => 'blockTitle'],
	];


	public function main(): array
	{
		extract($this->params);
		if ($this->getParentName()) {
			return get_defined_vars();
		}
		$this->renderBlock('content', get_defined_vars()) /* line 1 */;
		return get_defined_vars();
	}


	public function prepare(): void
	{
		extract($this->params);
		Nette\Bridges\ApplicationLatte\UIRuntime::initialize($this, $this->parentName, $this->blocks);
		
	}


	/** {block content} on line 1 */
	public function blockContent(array $ʟ_args): void
	{
		extract($this->params);
		extract($ʟ_args);
		unset($ʟ_args);
		$this->renderBlock('title', get_defined_vars()) /* line 2 */;
		echo '
<p>The page you requested could not be found. It is possible that the address is
incorrect, or that the page no longer exists. Please use a search engine to find
what you are looking for.</p>

<p><small>error 404</small></p>
';
	}


	/** {block title} on line 2 */
	public function blockTitle(array $ʟ_args): void
	{
		extract($this->params);
		extract($ʟ_args);
		unset($ʟ_args);
		echo '<h1>Page Not Found</h1>
';
	}

}
