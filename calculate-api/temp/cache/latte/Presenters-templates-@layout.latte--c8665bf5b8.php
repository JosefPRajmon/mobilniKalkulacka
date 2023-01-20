<?php

use Latte\Runtime as LR;

/** source: D:\wamp64\www\kalkulačka -  appmobile\mobilniKalkulacka\calculate-api\app\Presenters/templates/@layout.latte */
final class Templatec8665bf5b8 extends Latte\Runtime\Template
{
	protected const BLOCKS = [
		['scripts' => 'blockScripts'],
	];


	public function main(): array
	{
		extract($this->params);
		echo '
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width">

	<title>';
		if ($this->hasBlock("title")) /* line 9 */ {
			$this->renderBlock('title', [], function ($s, $type) {
				$ʟ_fi = new LR\FilterInfo($type);
				return LR\Filters::convertTo($ʟ_fi, 'html', $this->filters->filterContent('stripHtml', $ʟ_fi, $s));
			}) /* line 9 */;
			echo ' | ';
		}
		echo 'User Login Example</title>

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>

<body>
	<div class=container>
';
		$iterations = 0;
		foreach ($flashes as $flash) /* line 16 */ {
			echo '		<div';
			echo ($ʟ_tmp = array_filter(['alert', 'alert-' . $flash->type])) ? ' class="' . LR\Filters::escapeHtmlAttr(implode(" ", array_unique($ʟ_tmp))) . '"' : "" /* line 16 */;
			echo '>';
			echo LR\Filters::escapeHtmlText($flash->message) /* line 16 */;
			echo '</div>
';
			$iterations++;
		}
		echo "\n";
		$this->renderBlock('content', [], 'html') /* line 18 */;
		echo '	</div>

';
		if ($this->getParentName()) {
			return get_defined_vars();
		}
		$this->renderBlock('scripts', get_defined_vars()) /* line 21 */;
		echo '
</body>
</html>
';
		return get_defined_vars();
	}


	public function prepare(): void
	{
		extract($this->params);
		if (!$this->getReferringTemplate() || $this->getReferenceType() === "extends") {
			foreach (array_intersect_key(['flash' => '16'], $this->params) as $ʟ_v => $ʟ_l) {
				trigger_error("Variable \$$ʟ_v overwritten in foreach on line $ʟ_l");
			}
		}
		$this->createTemplate('components/form.latte', $this->params, "import")->render() /* line 1 */;
		Nette\Bridges\ApplicationLatte\UIRuntime::initialize($this, $this->parentName, $this->blocks);
		
	}


	/** {block scripts} on line 21 */
	public function blockScripts(array $ʟ_args): void
	{
		echo '	<script src="https://nette.github.io/resources/js/3/netteForms.min.js"></script>
';
	}

}
